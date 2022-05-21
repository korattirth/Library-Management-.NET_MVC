using LibararyManagement.Areas.Librarian.Repository;
using LibararyManagement.Filter;
using LibararyManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibararyManagement.Areas.Librarian.Controllers
{
    [Authentication]
    public class LibrarianController : Controller
    {
        private readonly ILibrarian _librarian;

        public LibrarianController(ILibrarian librarian)
        {
            _librarian = librarian;
        }
        // GET: Librarian/Librarian
        public ActionResult Index(int page = 1)
        {
            List<Pagination_Result> books = _librarian.getAllBooks(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (books.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public bool AddBook(Book book)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase profile = Request.Files[0];

            string ImageName = profile.FileName;
            var path = Path.Combine(Server.MapPath("/Images/"), ImageName);
            book.BookCoverPage = ImageName;
            _librarian.addBook(book);
            profile.SaveAs(path);
            return true;
        }
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            GetEditBook_Result model = _librarian.EditBook(id);
            return View(model);
        }
        [HttpPost]
        public bool EditBook(Book book)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase profile = Request.Files[0];

            string ImageName = profile.FileName;
            var path = Path.Combine(Server.MapPath("/Images/"), ImageName);
            book.BookCoverPage = ImageName;
            _librarian.EditBook(book);
            profile.SaveAs(path);
            return true;
        }
        [HttpGet]
        public ActionResult GetDeleteBook(int Id)
        {
            GetEditBook_Result model = _librarian.GetDeleteBook(Id);
            return View(model);
        }
        [HttpPost]
        public bool DeleteBook(int Id)
        {
            _librarian.DeleteBook(Id);
            return true;
        }
        public JsonResult getReaderData()
        {
            List<getReader_Result> list = _librarian.getReaderData();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool BookIssue(int BookId, DateTime IssueDate, int UserId, int status, DateTime ExpectedReturnDate)
        {
            _librarian.BookIssue(BookId, IssueDate, UserId, status, ExpectedReturnDate);
            return true;
        }
        [HttpPost]
        public bool returnBookDate(int BookId, DateTime ReturnDate)
        {
            _librarian.returnBookDate(BookId, ReturnDate);
            return true;
        }
        public ActionResult allAvailbleBook(int page = 1)
        {
            List<getAllAvailbleBook_Result> books = _librarian.getAllAvailbleBooks(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (books.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(books);
        }
        public ActionResult allIsuueBook(int page = 1)
        {
            List<getAllIssueBook_Result> books = _librarian.getAllIssueBooks(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (books.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(books);
        }
        public ActionResult historyOfIssueBook(int page = 1)
        {
            List<getAllIssueBookHistory_Result> books = _librarian.getAllHistoryIssueBooks(page);
            if (page != 1)
            {
                ViewBag.PreviousPage = page - 1;
            }
            if (books.Count < 3)
            {
                ViewBag.nextPagenum = page;
            }
            else
            {
                ViewBag.nextPagenum = page + 1;
            }
            ViewBag.pagenum = page;
            return View(books);
        }
        [HttpGet]
        public ActionResult blockUser()
        {
            List<getAllUser_Result> list = _librarian.blockUser();
            return View(list);
        }
        [HttpPost]
        public bool blockUser(int Id)
        {
            _librarian.blockUser(Id);
            return true;
        }
        [HttpPost]
        public bool unBlock(int Id)
        {
            _librarian.unBlock(Id);
            return true;
        }

    }
}