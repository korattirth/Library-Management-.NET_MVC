using LibararyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibararyManagement.Areas.Admin.Repository
{
    public class Admin : IAdmin
    {
        public List<getAllUsersWithLibrarian_Result> getAllUsersWithLibrarian()
        {
            using (var context = new Libarary_ManagementEntities())
            {
                List<getAllUsersWithLibrarian_Result> list = context.getAllUsersWithLibrarian().ToList();
                return list;
            }
        }
        public getEditUser_Result editUser(int Id)
        {
            using(var context = new Libarary_ManagementEntities())
            {
                getEditUser_Result model = context.getEditUser(Id).FirstOrDefault();
                return model;
            }
        }
        public bool editUser(int Id,string FirstName , string LastName,string PhoneNumber,string Address , string Email)
        {
            using(var context = new Libarary_ManagementEntities())
            {
                context.EditUser(Id, FirstName, LastName, PhoneNumber, Address, Email);
                return true;
            }
        }
        public getDeleteUser_Result getDeleteUser(int Id)
        {
            using(var context = new Libarary_ManagementEntities())
            {
                getDeleteUser_Result model = context.getDeleteUser(Id).FirstOrDefault();
                return model;
            }
        }
        public bool deleteUser(int Id)
        {
            using(var context = new Libarary_ManagementEntities())
            {
                context.deleteUser(Id);
                return true;
            }
        }

    }
}