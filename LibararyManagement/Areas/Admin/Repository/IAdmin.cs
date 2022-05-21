using LibararyManagement.Models;
using System;
using System.Collections.Generic;

namespace LibararyManagement.Areas.Admin.Repository
{
    public interface IAdmin
    {
        List<getAllUsersWithLibrarian_Result> getAllUsersWithLibrarian();
        getEditUser_Result editUser(int Id);
        bool editUser(int Id, string FirstName, string LastName, string PhoneNumber, string Address, string Email);
        getDeleteUser_Result getDeleteUser(int Id);
        bool deleteUser(int Id);
    }
}