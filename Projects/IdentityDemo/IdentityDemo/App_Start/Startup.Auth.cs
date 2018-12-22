using System;
namespace IdentityDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
            { 
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, 
                LoginPath = new PathString("/Accouny/Login")
            });
        }
    }
}
