using CafeOnline.Models;
using Model.DAO;
using Model.DTO;
using Model.EF;
using Models.Common;
using System;
using System.Web.Mvc;

namespace CafeOnline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserID, Encrypt.Encrypt_Code(model.Password), true);
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserID);
                    var userSession = new UserSession(user.UserID, user.GrantID);
                    Session.Add(Constants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không thành công.");
                }
            }
            return View("Login");
        }

        public ActionResult Register()
        {
            ViewBag.Success = "";
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserID(model.UserID))
                {
                    ViewBag.Success = "";
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserID = model.UserID;
                    user.Password = model.Password;
                    user.FullName = model.FullName;
                    user.Address = model.Address;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.GrantID = 2;
                    user.isActive = true;
                    user.CreatedAt = DateTime.Now;
                    var result = dao.Insert(user);
                    if (result != null)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModels();
                    }
                    else
                    {
                        ViewBag.Success = "";
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return Redirect("/Admin");
        }

        public ActionResult History()
        {
            return View();
        }
    }
}