using LibararyManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibararyManagement.Areas.Librarian.Repository
{
    public class Librarian : ILibrarian
    {
        public List<Pagination_Result> getAllBooks(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<Pagination_Result> books = context.Pagination(page, 3).ToList();
                return books;
            }
        }
        public List<getAllAvailbleBook_Result> getAllAvailbleBooks(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllAvailbleBook_Result> list = context.getAllAvailbleBook(page, 3).ToList();
                return list;
            }
        }
        public List<getAllIssueBook_Result> getAllIssueBooks(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllIssueBook_Result> list = context.getAllIssueBook(page, 3).ToList();
                return list;
            }
        }
        public List<getAllIssueBookHistory_Result> getAllHistoryIssueBooks(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllIssueBookHistory_Result> list = context.getAllIssueBookHistory(3, page).ToList();
                return list;
            }
        }
        public bool addBook(Book book)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                context.AddNewBook(book.BookName, book.Author, book.Subject, book.BookCoverPage, book.Language, book.Page);
                return true;
            }
        }
        public GetEditBook_Result EditBook(int id)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                GetEditBook_Result model = context.GetEditBook(id).FirstOrDefault();
                return model;
            }
        }
        public bool EditBook(Book book)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                context.AddEditBook(book.BookId, book.BookName, book.Author, book.Subject, book.BookCoverPage, book.Language, book.Page);
                return true;
            }
        }
        public GetEditBook_Result GetDeleteBook(int Id)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                GetEditBook_Result model = context.GetEditBook(Id).FirstOrDefault();
                return model;
            }
        }
        public bool DeleteBook(int Id)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                context.DeleteBook(Id);
                return true;
            }
        }
        public List<getReader_Result> getReaderData()
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getReader_Result> list = context.getReader().ToList();
                return list;
            }
        }
        public bool BookIssue(int BookId, DateTime IssueDate, int UserId, int status, DateTime ExpectedReturnDate)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                /*int total = context.addvalidationForBookIssue(UserId, IssueDate);
                if (context.addvalidationForBookIssue(UserId, IssueDate) < 4)
                {
                    return true;
                }*/
                context.addBookIssueData(BookId, UserId, IssueDate, ExpectedReturnDate);
                context.addStatus(BookId, status);
                return true;
            }
        }
        public bool returnBookDate(int BookId, DateTime ReturnDate)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                context.cheakReturnDateForStatus(ReturnDate, BookId);
                return true;
            }
        }
        public List<getAllUser_Result> blockUser()
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllUser_Result> list = context.getAllUser().ToList();
                return list;
            }
        }
        public bool blockUser(int Id)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                context.blockUser(Id);
                return true;
            }
        }
        public bool unBlock(int Id)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                context.unBlockUser(Id);
                return true;
            }
        }
    }
}