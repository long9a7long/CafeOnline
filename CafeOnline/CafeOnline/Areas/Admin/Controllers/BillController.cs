using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class BillController:BaseController
    {
        public ActionResult Index(string searchString, int page = 1)
        {
            var billDao = new BillDAO();
            var model = billDao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public JsonResult Delete(int id)
        {
            var result = CategoryDAO.Instance.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditCount(int orderID, int count)
        {
            var result = OrderDAO.Instance.Update(orderID, count);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int billID)
        {
            var bill = new BillDAO().GetByID(billID);
            ViewBag.BillID = billID;
            return View(bill);
        }
        public void SetOrderViewBag(int billID)
        {
            var dao = new OrderDAO();
            var listOrder = dao.ListByNameProduct(billID);
        }
    }
}