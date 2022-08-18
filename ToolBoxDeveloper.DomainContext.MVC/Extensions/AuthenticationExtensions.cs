using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ToolBoxDeveloper.DomainContext.MVC.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddAuthenticationConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(opt =>
              {
                  opt.LoginPath = new PathString("/Autentication/Index");
                  opt.LogoutPath = new PathString("/Autentication/Logout");
                  opt.Cookie = new CookieBuilder()
                  {
                      Name = "DomainContext",
                  };
              });
        }
    }
}
