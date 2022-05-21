using LibararyManagement.Models;
using System;
using System.Collections.Generic;

namespace LibararyManagement.Areas.Librarian.Repository
{
    public interface ILibrarian
    {
        bool addBook(Book book);
        List<getAllUser_Result> blockUser();
        bool blockUser(int Id);
        bool BookIssue(int BookId, DateTime IssueDate, int UserId, int status, DateTime ExpectedReturnDate);
        bool DeleteBook(int Id);
        bool EditBook(Book book);
        GetEditBook_Result EditBook(int id);
        List<getAllAvailbleBook_Result> getAllAvailbleBooks(int page);
        List<Pagination_Result> getAllBooks(int page);
        List<getAllIssueBookHistory_Result> getAllHistoryIssueBooks(int page);
        List<getAllIssueBook_Result> getAllIssueBooks(int page);
        GetEditBook_Result GetDeleteBook(int Id);
        List<getReader_Result> getReaderData();
        bool returnBookDate(int BookId, DateTime ReturnDate);
        bool unBlock(int Id);
    }
}