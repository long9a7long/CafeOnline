using Model.DAO;
using Model.EF;
using System;
using System.Web.Mvc;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class GrantController : System.Web.Mvc.Controller
    {
        // GET: Admin/Grant
        public ActionResult Index()
        {
            var dao = new GrantDao();
            var model = dao.GetListAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Grant grant)
        {
            if (ModelState.IsValid)
            {
                var dao = new GrantDao();
                if (dao.GetByName(grant.GrantName) == null)
                {
                    int id = dao.Insert(grant);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Grant");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm phân quyền không thành công !");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Phân quyền đã tồn tại !");
            }

            return View("Index");
        }

        public JsonResult EditName(int id, string name)
        {
            var result = GrantDao.Instance.UpdateName(id, name);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = GrantDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var result = GrantDao.Instance.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}