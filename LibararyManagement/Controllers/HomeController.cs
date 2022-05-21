using LibararyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibararyManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpGet]
        public ActionResult SignUp()
        {
            var list = new List<Role>()
            {
                new Role(){Id = 1 ,UserRole = "User"},
                new Role(){Id = 2 ,UserRole = "Librarian"}
            };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserDetail user)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Libarary_ManagementEntities())
                {
                    if(user.UserTypeId == 1){
                        user.IsActive = 1; /*1 is Active State*/
                    }
                    else
                    {
                        user.IsActive = 0;
                    }
                    context.AddUserDetail(user.FirstName, user.LastName, user.PhoneNumber, user.Email, user.Address, user.Password,user.UserTypeId,user.IsActive);
                    return View("Login");
                }
            }
            else
            {
                return View("Signup");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Libarary_ManagementEntities())
                {
                    LoginUser_Result result = context.LoginUser(model.Email, model.Password).FirstOrDefault();
                    if(result.IsActive == 0)
                    {
                        ViewBag.Error = "User Does Not Exist";
                        return View("Login");
                    }
                    else
                    {
                        Session["UserID"] = result.UserId.ToString();
                        Session["UserTypeId"] = result.UserTypeId.ToString();
                        return View("Index");
                    }       
                }
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserTypeId"] = null;
            return View("Login");
        }
    }
}