using LibararyManagement.Areas.User.Repository;
using LibararyManagement.Filter;
using LibararyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibararyManagement.Areas.User.Controllers
{
    [Authentication_User]
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        // GET: User/Admin
        public ActionResult Index(int page = 1)
        {
            List<Pagination_Result> list = _user.getAllBooks(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (list.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(list);
        }
        public ActionResult allAvailbleBook(int page = 1)
        {
            List<getAllAvailbleBook_Result> list = _user.allAvailbleBook(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (list.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(list);
        }
        public ActionResult allIsuueBook(int page = 1)
        {
            List<getAllIssueBook_Result> list = _user.allIsuueBook(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (list.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(list);
        }
    }
}