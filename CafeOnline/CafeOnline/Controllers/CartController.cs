using CafeOnline.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOnline.Controllers
{
    public class CartController : Controller
    {
        private string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                 list = (List<CartItem>)cart;
            }
           
            return View(list);
        }
        public ActionResult AddItem(int productId, int Count)
        {
            var product = new ProductDao().getByID(productId);
            var cart = Session[CartSession];
            if(cart!=null)
            {
                var list = (List < CartItem >) cart;
                if (list.Exists(x => x.Product.ProdID == productId))
                {
                    foreach(var item in list)
                    {
                        if (item.Product.ProdID == productId)
                        {
                            item.Count += Count;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Count = Count;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Count = Count;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}