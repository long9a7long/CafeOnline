using Model.DTO;
using Models.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserSession)Session[Constants.USER_SESSION];
            if (session == null || session.GrantID != 1)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            //else if (session.GrantID != 1)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new
            //        RouteValueDictionary(new { controller = "Home", action = "Index"}));
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}