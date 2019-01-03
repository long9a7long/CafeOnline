using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    
   public class BillDao
    {
        ShopDbContext db = null;
        public BillDao()
        {
            db = new ShopDbContext();
        }
        public int Insert(Bill bill)
        {
            db.Bill.Add(bill);
            db.SaveChanges();
            return bill.BillID;
        }
    }
}
