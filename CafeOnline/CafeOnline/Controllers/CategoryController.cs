using Model.DAO;
using System.Web.Mvc;

namespace CafeOnline.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            var model = new CategoryDAO().ListAll();
            return View(model);
        }
    }
}