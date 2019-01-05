using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class OrderDAO
    {
        ShopDbContext db = null;
        public OrderDAO()
        {
            db = new ShopDbContext();
        }
        public bool Insert(Order order)
        {
            try
            {
                db.Order.Add(order);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static OrderDAO instance;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }
        public Order GetByID(int orderID)
        {
            return db.Order.SingleOrDefault(x => x.OrderID == orderID);
        }
        public IEnumerable<Order> GetByIDBill(int IDBill)
        {
            IQueryable<Order> model = db.Order;
            model = model.Where(x => x.BillID == IDBill);
            return model;
        }
        public bool Update(int orderID, int count)
        {
            var order = GetByID(orderID);
            order.Count = count;
            order.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return true;
        }
        public List<OrderViewModel> ListByNameProduct(int billID)
        {
            var model = (from a in db.Product
                         join b in db.Order
                         on a.ProdID equals b.ProdID
                         join c in db.Bill
                         on b.BillID equals c.BillID
                         where b.BillID == billID
                         select new OrderViewModel
                         {
                             ProdID = a.ProdID,
                             ProdName = a.ProdName,
                             BillID = c.BillID,
                             Count = b.Count,
                             CreatedAt = b.CreatedAt,
                             UpdatedAt = b.UpdatedAt,
                             OrderID = b.OrderID
                         });
            model.OrderByDescending(x => x.CreatedAt);
            return model.ToList();
        }
    }
}
