using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MusicApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public string UserFirstName
        {
            get
            {
                string firstName = string.Empty;

                if (User != null && User.HasClaim(c=> c.Type == "firstName"))
                {
                    firstName = User.Claims.FirstOrDefault(c => c.Type == "firstName")
                    ?.Value ?? firstName; 
                }

                return firstName;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.UserFirstName = UserFirstName;
            base.OnActionExecuted(context);
        }
    }
}
