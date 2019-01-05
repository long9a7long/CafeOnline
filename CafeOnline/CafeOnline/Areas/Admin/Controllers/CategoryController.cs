using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1)
        {
            var catedao = new CategoryDAO();
            var model = catedao.ListAllPaging(searchString,page);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                if (dao.GetByID(category.CateID) == null)
                {
                    int id = dao.Insert(category);
                    if (id >0)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm danh mục không thành công !");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Danh mục đã tồn tại !");
            }

            return View("Index");
        }

        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = CategoryDAO.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = CategoryDAO.Instance.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditName(int cateID, string cateName)
        {
            var result = CategoryDAO.Instance.UpdateName(cateID, cateName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}