using CafeOnline.Areas.Admin.Models;
using Model.DAO;
using Model.DTO;
using Models.Common;
using System.Web.Mvc;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class LoginController : System.Web.Mvc.Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encrypt.Encrypt_Code(model.Password), true);
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
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
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return Redirect("/Admin");
        }
    }
}