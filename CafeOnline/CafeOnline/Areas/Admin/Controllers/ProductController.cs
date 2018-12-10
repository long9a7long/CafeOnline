using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class ProductController : System.Web.Mvc.Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(page);
            return View(model);
        }
        public ActionResult Create()
        {
            //SetCategoryViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                if (ProductDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại!");
                }
            }
            //SetCategoryViewBag();
            return View();
        }
        public void SetCategoryViewBag(int? selectedID = null)
        {
            //var listCategory = CategoryDao.Instance.GetListCategory();
            //ViewBag.CategoryID = new SelectList(listCategory, "CateID", "CateName", selectedID);
        }

        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = ProductDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var result = ProductDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}