using LibararyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibararyManagement.Areas.User.Repository
{
    public class User : IUser
    {
        public List<Pagination_Result> getAllBooks(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<Pagination_Result> books = context.Pagination(page, 3).ToList();

                return books;
            }
        }
        public List<getAllAvailbleBook_Result> allAvailbleBook(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllAvailbleBook_Result> list = context.getAllAvailbleBook(page, 3).ToList();

                return list;
            }
        }
        public List<getAllIssueBook_Result> allIsuueBook(int page)
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllIssueBook_Result> list = context.getAllIssueBook(page, 3).ToList();

                return list;
            }
        }
    }
}