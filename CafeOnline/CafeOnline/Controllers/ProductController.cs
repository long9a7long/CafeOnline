using Model.DAO;
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