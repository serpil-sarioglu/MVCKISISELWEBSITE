using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCKISISELWEBSITE.Filters
{
    public class LoginFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.Keys.Contains("userName"))
            {
                var controller = (Controller)context.Controller;
                context.Result = controller.RedirectToAction("Login", "Admin");
            }
        }
    }
}
