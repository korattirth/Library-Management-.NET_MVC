using System.Web.Mvc;

namespace LibararyManagement.Areas.Librarian
{
    public class LibrarianAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Librarian";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Librarian_default",
                "Librarian/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}