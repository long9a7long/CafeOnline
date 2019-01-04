﻿using System;
using Model.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            var totalproduct = 100;
            var productDao = new ProductDao();
            ViewBag.pageIndex = page;
            ViewBag.product = productDao.ListNewProduct(totalproduct);
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
    }
}