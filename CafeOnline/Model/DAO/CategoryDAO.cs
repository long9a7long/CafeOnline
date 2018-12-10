using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
    public class CategoryDAO
    {
         ShopDbContext db = null;
         public CategoryDAO()
        {
            db = new ShopDbContext();
        }
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }
        public IEnumerable<Category> ListAllPaging(int page, int pageSize)
        {   
            return db.Category.OrderByDescending(x => x.CreatedAt).ToPagedList(page, pageSize);
        }
        public int Insert(Category entity)
        {
            entity.CreatedAt = DateTime.Now;
            db.Category.Add(entity);
            db.SaveChanges();
            return entity.CateID;
        }
        public Category GetByName(int cateID)
        {
            return db.Category.SingleOrDefault(x => x.CateID == cateID);
        }
        public bool Delete(int cateID)
        {
            try
            {
                var cate = db.Category.Find(cateID);
                db.Category.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Category> GetListAll()
        {
            return db.Category.OrderByDescending(x => x.CateID).ToList();
        }
    }
}
