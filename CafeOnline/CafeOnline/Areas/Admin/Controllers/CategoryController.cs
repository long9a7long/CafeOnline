using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class CategoryController : System.Web.Mvc.Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int page=1, int pageSize=10)
        {
            var catedao = new CategoryDAO();
            var model = catedao.ListAllPaging(page, pageSize);
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
                if (dao.GetByName(category.CateID) == null)
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
        [HttpDelete]
       
        public ActionResult Delete (int cateID)
        {
            new CategoryDAO().Delete(cateID);
            return RedirectToAction("Index");
        }
    }
}