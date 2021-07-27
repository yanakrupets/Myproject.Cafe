using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers.CustomAttribute
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext context)
        {
            var _userService = (UserService)context
                .HttpContext
                .RequestServices
                .GetService(typeof(IUserService));
            if (!_userService.IsAdmin())
            {
                context.Result = new ForbidResult();
            }
            base.OnActionExecuting(context);
        }
    }
}
