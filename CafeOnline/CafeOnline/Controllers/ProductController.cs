using CafeOnline.Models;
using Model.DAO;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Common;

namespace CafeOnline.Controllers
{
    public class ProductController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Product
        public ActionResult Index()
        {
           

            return View();
        }
        [HttpPost]
        public ActionResult Detail(string sl, string prodId)
        {
            var product = new ProductDao().getByID(Convert.ToInt32(prodId));
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ProdID == Convert.ToInt32(prodId)))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ProdID == Convert.ToInt32(prodId))
                        {
                            item.Count += Convert.ToInt32(sl);
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Count = Convert.ToInt32(sl);
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Count = Convert.ToInt32(sl);
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            ViewBag.Relateproduct = new ProductDao().ListRelateProduct(Convert.ToInt32(prodId));
            return View(product);
        }
       
        public ActionResult Detail(int id)
        {
            var product = new ProductDao().getByID(id);
            ViewBag.Relateproduct = new ProductDao().ListRelateProduct(id);
            return View(product);
        }


        public ActionResult Product (int pageIndex=1)
        {
            //var category = new CategoryDAO().ViewDetail(productId);
            //ViewBag.Category = category;
            int totalRecord = 0;///tong ban ghi cua danh muc
            var product = new ProductDao().ListByCategoryId(ref totalRecord, pageIndex);
            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;

            int maxPage = 3;//so trang hien thi toi da treng trang
            int totalPage = 0; //tong so trang tính ra
            totalPage = (int)Math.Ceiling((double)(totalRecord / Constants.PageSize))+1;//chia tong ban ghi cho so luong tren trang, làm tron len
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;//trang cuoi cung
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            return View(product);
        }

       
    }
}