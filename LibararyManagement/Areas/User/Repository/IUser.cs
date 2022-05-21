using LibararyManagement.Models;
using System.Collections.Generic;

namespace LibararyManagement.Areas.User.Repository
{
    public interface IUser
    {
        List<getAllAvailbleBook_Result> allAvailbleBook(int page);
        List<getAllIssueBook_Result> allIsuueBook(int page);
        List<Pagination_Result> getAllBooks(int page);
    }
}