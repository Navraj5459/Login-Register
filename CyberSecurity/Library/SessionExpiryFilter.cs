using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace CyberSecurity.Library
{
    public class SessionExpiryFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var keyslist = filterContext.HttpContext.Session.Keys;
            if (keyslist.Contains("UserId"))
            {
                if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("UserId")))
                {
                    filterContext.HttpContext.Session.Clear();
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "LogOff" }));
                }
            }
            else
            {
                filterContext.HttpContext.Session.Clear();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "LogOff" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
