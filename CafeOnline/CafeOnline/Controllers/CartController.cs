using CafeOnline.Models;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CafeOnline.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
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
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ProdID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart= (List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProdID == item.Product.ProdID);
                if (jsonItem != null)
                {
                    item.Count = jsonItem.Count;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
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
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName,string phone,string address,string note)
        {
            var bill = new Bill();
            bill.CreatedAt = DateTime.Now;
            bill.CustomerName = shipName;
            bill.DeliveryAddress = address;
            bill.Phone = phone;
            bill.Note = note;
            try
            {
                var id = new BillDao().Insert(bill);
                var cart = (List<CartItem>)Session[CartSession];
                var orderDao = new OrderDao();
                foreach(var item in cart)
                {
                    var order = new Order();
                    order.ProdID = item.Product.ProdID;
                    order.BillID = id;
                    order.Count = item.Count;
                    order.CreatedAt = DateTime.Now;
                    orderDao.Insert(order);
                }
            }
            catch(Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }

    }
}