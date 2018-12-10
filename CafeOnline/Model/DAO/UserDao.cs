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
        private const string paramOne = "@uname";
        private const string paramTwo = "@passwd";
        private const string MP_UserLogin = "MP_UserLogin " + paramOne + ", " + paramTwo;

        public UserDao()
        {
            db = new ShopDbContext();
        }

        public string Insert (User entity )
        {
            entity.Password = Encrypt.Encrypt_Code(entity.Password);
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

    }
}
