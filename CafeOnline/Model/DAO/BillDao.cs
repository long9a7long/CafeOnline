using Model.EF;
using PagedList;
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
        private static BillDao instance;
        public static BillDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDao();
                }
                return instance;
            }
        }
        public IEnumerable<Bill> ListAllPaging(int page, int pageSize)
        {
            return db.Bill.OrderByDescending(x => x.CreatedAt).ToPagedList(page, pageSize);
        }
        public int Insert(Bill entity)
        {
            entity.CreatedAt = DateTime.Now;
            db.Bill.Add(entity);
            db.SaveChanges();
            return entity.BillID;
        }
        public Bill GetByName(int ID)
        {
            return db.Bill.SingleOrDefault(x => x.BillID == ID);
        }
        public bool Delete(int ID)
        {
                var bill = db.Bill.Find(ID);
                db.Bill.Remove(bill);
                db.SaveChanges();
                return true;
        }

        public List<Bill> GetListAll()
        {
            return db.Bill.OrderByDescending(x => x.BillID).ToList();
        }
    }
}
