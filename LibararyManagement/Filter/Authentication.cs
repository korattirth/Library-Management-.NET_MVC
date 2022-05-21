using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LibararyManagement.Filter
{
    public class Authentication : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (String.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else if(Convert.ToInt32(filterContext.HttpContext.Session["UserTypeId"]) == 1)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            Console.WriteLine(Convert.ToString(filterContext.HttpContext.Session["UserTypeId"]));
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = CreateResult(filterContext);
            }
        }
        protected ActionResult CreateResult(AuthorizationContext filterContext)
        {
            return new ViewResult
            {
                ViewName = "Error"
            };
        }
    }
}