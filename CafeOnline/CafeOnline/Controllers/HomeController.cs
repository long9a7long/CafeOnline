using CafeOnline.Models;
using Model.Common;
using Model.DAO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CafeOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search_kw="", int page = 1)
        {
                var totalproduct = 100;
                var productDao = new ProductDao();
                ViewBag.pageIndex = page;
                ViewBag.keyword = search_kw;
                ViewBag.product = productDao.ListNewProduct(totalproduct,search_kw);
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Your cart page.";
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.Message = "Your checkout page.";
            return View();
        }

        public PartialViewResult CartDetail()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}