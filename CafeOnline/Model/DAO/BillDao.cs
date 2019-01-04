using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    
   public class BillDAO
    {
        ShopDbContext db = null;
        public BillDAO()
        {
            db = new ShopDbContext();
        }
        public int Insert(Bill bill)
        {
            db.Bill.Add(bill);
            db.SaveChanges();
            return bill.BillID;
        }
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                }
                return instance;
            }
        }
        public IEnumerable<Bill> ListAllPaging(string searchString, int page)
        {
            IQueryable<Bill> model = db.Bill;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CustomerName.Contains(searchString) || x.DeliveryAddress.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedAt).ToPagedList(page, Constants.PageSize);
        }
        public bool Delete(int billID)
        {
            try
            {
                var bill = db.Bill.Find(billID);
                db.Bill.Remove(bill);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Bill GetByID(int billID)
        {
            return db.Bill.SingleOrDefault(x => x.BillID == billID);
        }
    }
}
