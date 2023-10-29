using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GK.Cryptoman.Hub.Controllers
{
    public abstract class BaseController : Controller
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Implement a common behaviour?
            return base.OnActionExecutionAsync(context, next);
        }

    }
}
