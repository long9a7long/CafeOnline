using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class GrantDao
    {
        private ShopDbContext db = null;

        public GrantDao()
        {
            db = new ShopDbContext();
        }

        private static GrantDao instance;

        public static GrantDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GrantDao();
                }
                return instance;
            }
        }
        public List<Grant> ListAll()
        {
            return db.Grant.Where(x=>x.isActive==true).ToList();
        }

        /// <summary>
        /// Phương thức lấy ds tất cả các quyền bao gồm active và non-active
        /// </summary>
        /// <returns></returns>
        public List<Grant> GetListAll()
        {
            return db.Grant.OrderByDescending(x=>x.CreatedAt).ToList();
        }

        public int Insert(Grant entity)
        {
            entity.CreatedAt = DateTime.Now;
            db.Grant.Add(entity);
            db.SaveChanges();
            return entity.GrantID;
        }

        public bool UpdateName(int id,string name)
        {
            var grant = GetByID(id);
            grant.GrantName = name;
            grant.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        public Grant GetByID(int grantID)
        {
            return db.Grant.SingleOrDefault(x => x.GrantID == grantID);
        }

        public Grant GetByName(string name)
        {
            return db.Grant.SingleOrDefault(x => x.GrantName == name);
        }

        public bool Delete(int grantID)
        {
            try
            {
                var grant = db.Grant.Find(grantID);
                db.Grant.Remove(grant);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool changeStatus(int id)
        {
            var grant = GetByID(id);
            grant.isActive = !grant.isActive;
            grant.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return grant.isActive;
        }

    }
}
