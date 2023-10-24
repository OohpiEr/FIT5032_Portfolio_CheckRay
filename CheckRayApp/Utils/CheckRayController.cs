using System.Web.Mvc;
using CheckRayApp.Models;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;
using CheckRay.Context;

namespace CheckRayApp.Utils
{
    // Custom controller.
    public class CheckRayController : Controller
    {
        protected CheckRayAppContext db = new CheckRayAppContext();
        protected User currentUser = null;
        protected User GetCurrentUser()
        {
            if (currentUser == null)
            {
                string userId = User.Identity.GetUserId();

                User user = db.Users.Where(u => u.UserId == userId).ToList().First();
                currentUser = user;
            }

            return currentUser;
        }

        protected bool CheckAdminRole(bool redirect)
        {
            User user = GetCurrentUser();

            if (!user.isAdmin())
            {
                if (redirect)
                {
                    Response.Redirect("home", false);
                }
                return false;
            }

            return true;

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.isAdmin = false;
            if (User.Identity.IsAuthenticated)
            {
                //ViewBag.isAdmin = CheckAdminRole(false);
            }
        }
    }
}
