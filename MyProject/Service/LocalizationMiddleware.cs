using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userService =
                (UserService)context.RequestServices
                .GetService(typeof(IUserService));

            var user = userService.GetCurrent();
            if (user == null)
            {
                var langKey = context.Request.Cookies["guestLang"] as string;
                switch (langKey)
                {
                    case "en":
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("en-US");
                        break;
                    case "ru":
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("ru-RU");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (user.Language)
                {
                    case EfStuff.Model.Language.en:
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("en-US");
                        break;
                    case EfStuff.Model.Language.ru:
                        CultureInfo.DefaultThreadCurrentUICulture
                            = new CultureInfo("ru-RU");
                        break;
                    default:
                        break;
                }
            }

            await _next(context);
        }
    }
}
