using LibararyManagement.Areas.Admin.Repository;
using LibararyManagement.Areas.Librarian.Repository;
using LibararyManagement.Areas.User.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LibararyManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUser, User>();
            container.RegisterType<ILibrarian, Librarian>();
            container.RegisterType<IAdmin, Admin>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}