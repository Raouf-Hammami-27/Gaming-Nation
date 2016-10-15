using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GUI.Models;
using TAG_Domain.Entities;
using TAG_DATA.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Web.Security;
using System.Security.Policy;
using System.IO;
using System.Collections.Generic;

namespace GUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,IRoleStore<IdentityRole> roleStore )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new tagContext()));

        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // find user by username first
                var user = await UserManager.FindByNameAsync(model.username);
                IList<string> role = await UserManager.GetRolesAsync(user.Id);


                if (user != null)
                {
                    var validCredentials = await UserManager.FindAsync(model.username, model.Password);

                    // When a user is lockedout, this check is done to ensure that even if the credentials are valid
                    // the user can not login until the lockout duration has passed
                   
                    if (await UserManager.IsLockedOutAsync(user.Id))
                    {
                        if (user.ban == true)
                        {
                            ModelState.AddModelError("", string.Format("Your account has been locked out for 3 days due to ban by the administrator"));
                        }
                        else if (UserManager.MaxFailedAccessAttemptsBeforeLockout >= 3)
                        {
                            ModelState.AddModelError("", string.Format("Your account has been locked out for {0} minutes due to multiple failed login attempts.", ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"].ToString()));
                        }
                      

                    }
                    // if user is subject to lockouts and the credentials are invalid
                    // record the failure and check if user is lockedout and display message, otherwise,
                    // display the number of attempts remaining before lockout
                    else if (await UserManager.GetLockoutEnabledAsync(user.Id) && validCredentials == null)
                    {
                        // Record the failure which also may cause the user to be locked out
                        await UserManager.AccessFailedAsync(user.Id);

                        string message;

                        if (await UserManager.IsLockedOutAsync(user.Id))
                        {
                            message = string.Format("Your account has been locked out for {0} minutes due to multiple failed login attempts.", ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"].ToString());
                        }
                        else
                        {
                            int accessFailedCount = await UserManager.GetAccessFailedCountAsync(user.Id);

                            int attemptsLeft =
                                Convert.ToInt32(
                                    ConfigurationManager.AppSettings["MaxFailedAccessAttemptsBeforeLockout"].ToString()) -
                                accessFailedCount;

                            message = string.Format(
                                "Invalid credentials. You have {0} more attempt(s) before your account gets locked out.", attemptsLeft);

                        }

                        ModelState.AddModelError("", message);
                    }
                    else if (validCredentials == null)
                    {
                        ModelState.AddModelError("", "Invalid credentials. Please try again.");
                    }
                    else
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // When token is verified correctly, clear the access failed count used for lockout
                        await UserManager.ResetAccessFailedCountAsync(user.Id);
                        var usr = await user.GenerateUserIdentityAsync(UserManager);

                        if (usr.IsAuthenticated)
                        {
                            //Role Member
                            if (role[0] == "Member")
                            {

                                return RedirectToAction("About", "Home");
                            }
                            else //Role Admin
                            if (role[0] == "Administrator")
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else if (role[0] == "Event_Organizer")
                            {
                                
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToAction("Error", "Home");
                            }
                        }
                        else
                        {
                            return RedirectToAction("Error", "Home");
                        }
                        
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
       

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //HttpPostedFileBase idFile ;
            if (ModelState.IsValid)
            {
                var User = new member { UserName = model.username, Email = model.Email, firstName = model.FirstName, lastName = model.lastName, DTYPE = "Member", role = "Member", image_link = "~/Content/img/avatar.jpg"};
                var username = model.username;
                var image_link = model.image_link;
                ViewBag.image_link = image_link;

                var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new tagContext()));
                if (!roleManager.RoleExists("Member"))
                {
                    var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    Role.Name = "Member";
                    roleManager.Create(Role);
                }
                   tagContext ctx = new tagContext();
                var result = await UserManager.CreateAsync(User, model.Password);
                var role = UserManager.AddToRole(User.Id, "Member");
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(User.Id);
                var callbackUrl = Url.Action(
                   "ConfirmEmail", "Account",
                   new { userId = User.Id, code = code },
                   protocol: Request.Url.Scheme);

                await UserManager.SendEmailAsync(User.Id,
                   "Confirm your account",
                   "Please confirm your account by clicking this link: <a href=\""
                                                   + callbackUrl + "\">link</a>");

                ctx.SaveChanges();


                return View("DisplayEmail");
            }
                
            

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            IdentityResult result;
            try
            {
                result = await UserManager.ConfirmEmailAsync(userId, code);
            }
            catch (InvalidOperationException ioe)
            {
                // ConfirmEmailAsync throws when the userId is not found.
                ViewBag.errorMessage = ioe.Message;
                return View("Error");
            }

            if (result.Succeeded)
            {
                return View();
            }

            // If we got this far, something failed.
            AddErrors(result);
            ViewBag.errorMessage = "ConfirmEmail failed";
            return View("Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    return View("ForgotPasswordConfirmation");
                }

                var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account",
                new { UserId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password",
                "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email,Username=loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var User = new member
                {
                    UserName = model.Username,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    HomeTown = model.HomeTown,
                    role = "Member",
                    DTYPE = "Member"
                };
                if (loginInfo.Login.LoginProvider.Contains("Google"))
                {

                    User.socialAuth = 1;
                }
                else if (loginInfo.Login.LoginProvider.Contains("Facebook"))
                { User.socialAuth = 2; }
                var result = await UserManager.CreateAsync(User);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(User.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(User, isPersistent: false, rememberBrowser: false);

                        return RedirectToLocal(returnUrl);
                    }

                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("About", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}