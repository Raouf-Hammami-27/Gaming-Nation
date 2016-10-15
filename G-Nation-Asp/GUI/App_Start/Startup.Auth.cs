using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using GUI.Models;
using TAG_DATA.Models;
using TAG_Domain.Entities;
using Owin.Security.Providers.Twitch;

namespace GUI
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(tagContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "oB0BFRJOiRRtICrPlIyHr730W",
            //    consumerSecret: "IMdmYQSkNOMMhD4kN6qmdPUijvkPlRGvBvRqhx5QNG6fKTVWlo");

            app.UseFacebookAuthentication(
            appId: "1651381111770506",
            appSecret: "3be1a8a9a949507b9f674da022212b19");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "667051559939-pu1h6ibq07kbadrqi8ahg53vj2lmprvl.apps.googleusercontent.com",
                ClientSecret = "7YOwaSyGtLJURcDSUkSeu5mh"
            });

            //var options = new TwitchAuthenticationOptions
            //{
            //    ClientId = "d1huu49kq81916thejgpyn9r6x8kml6",
            //    ClientSecret = "i6l63ppyexjuqwwyd131qwsg1fik0oe",
            //   // CallbackPath = new PathString("http://localhost:5303/signin-Twitch")
            //};
            //app.UseTwitchAuthentication(options);
            ////app.UseGitHubAuthentication(options => {
            ////    options.ClientId = "49e302895d8b09ea5656";
            ////    options.ClientSecret = "98f1bf028608901e9df91d64ee61536fe562064b";
            ////};
            //var opt = new GitHubAuthenticationOptions
            //{
            //    ClientId = "6d686e16987995b51bc2",
            //    ClientSecret = "cf519b0fc1857159e6a8274f76276dea5641804f",

            //};
            //app.UseGitHubAuthentication(opt);
            //app.UseSteamAuthentication("758D7136AF8786CC4A2EA55E4BB34016");
        }
    }
}