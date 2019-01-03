using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            var product = new ProductDao().getByID(5);
            ViewBag.Relateproduct = new ProductDao().ListRelateProduct(5);
            return View(product);
        }
    }
}