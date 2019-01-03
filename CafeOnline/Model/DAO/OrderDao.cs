using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDao()
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
    }
}
