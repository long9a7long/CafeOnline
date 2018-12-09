using System.Web.Mvc;
using Model.EF;
using Model.DAO;
namespace CafeOnline.Areas.Admin.Controllers
{
    public class UserController : System.Web.Mvc.Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        } 
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.GetByName(user.UserID) == null)
                {
                    string id = dao.Insert(user);
                    if (id != null)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm Người Dùng Không Thành Công !");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Người Dùng Đã Tồn Tại !");
                }
            }
            return View("Index");
            
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new GrantDao();
            ViewBag.GrantID = new SelectList(dao.ListAll(), "GrantID", "GrantName", selectedID);
        }

    }
}