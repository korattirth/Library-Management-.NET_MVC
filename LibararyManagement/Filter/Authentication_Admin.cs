using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LibararyManagement.Filter
{
    public class Authentication_Admin : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (String.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else if (Convert.ToInt32(filterContext.HttpContext.Session["UserTypeId"]) == 1 || Convert.ToInt32(filterContext.HttpContext.Session["UserTypeId"]) == 2)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
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