using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Models.Common;
using System.Data.SqlClient;

namespace Model.DAO
{

    public class UserDao
    {


        ShopDbContext db = null;

        private static UserDao instance;

        public static UserDao Instance
        {
            get { if (instance == null) instance = new UserDao(); return UserDao.instance; }
            set { UserDao.instance = value; }
        }

        public UserDao()
        {
            db = new ShopDbContext();
        }

        public string Insert(User entity)
        {
            entity.Password = Encrypt.Encrypt_Code(entity.Password);
            entity.CreatedAt = DateTime.Now;
            db.User.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page)
        {

            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserID.Contains(searchString) || x.FullName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedAt).ToPagedList(page, Constants.PageSize);


        }

        public User GetByName(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserID == userName);
        }
        public int Login(string userID, string passWord, bool isLoginAdmin = false)
        {
            var result = db.User.SingleOrDefault(x => x.UserID == userID);
            if (result == null)
            {
                return 0;//tài khoản ko tồn tại
            }
            else
            {
                if (isLoginAdmin == true)
                {

                    if (result.isActive == false)
                    {
                        return -1; //tài khoản bị khóa
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1; //đăng nhập thành công
                        else
                            return -2; //mk ko đúng
                    }

                }
                else
                {
                    if (result.isActive == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
        public bool changeStatus(string userID)
        {
            var user = GetByName(userID);
            user.isActive = !user.isActive;
            user.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return user.isActive;
        }
        public bool Delete(string userID)
        {
            try
            {
                var user = db.User.Find(userID);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateName(string userID, string name)
        {
            var user = GetByName(userID);
            user.FullName = name;
            user.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return true;
        }


    }
}
