using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(Startup))]
public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        app.CreatePerOwinContext(AppDbContext.Create);
        app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
        app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);
        app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
            Provider = new CookieAuthenticationProvider
            {
                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<AppUserManager, AppUser>(
                    validateInterval: TimeSpan.FromMinutes(5),
                    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            }
        });
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
    }
}