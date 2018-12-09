using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    
    public class UserDao
    {
        ShopDbContext db = null;

        public UserDao()
        {
            db = new ShopDbContext();
        }

        public string Insert (User entity )
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            //return db.User.ToPagedList(page,pageSize);
            return model.OrderByDescending(x => x.CreatedAt).ToPagedList(page, pageSize);

        }

        public User GetByName(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserID == userName);
        }
        public bool Login ( string userName, string passWord)
        {
            return false;
        }

        




    }
}
