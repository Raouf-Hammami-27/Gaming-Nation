using GUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TAG_DATA.Models;
using TAG_Domain.Entities;

namespace GUI
{
    public class AuthRepository : IDisposable
    {
        private tagContext _ctx;

        private UserManager<User> _userManager;
        UrlHelper Url;
        HttpRequestBase Request;
        public AuthRepository()
        {
            _ctx = new tagContext();
            _userManager = new UserManager<User>(new UserStore<User>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel model)
        {
            
            var User = new member { UserName = model.username, Email = model.Email, firstName = model.FirstName, lastName = model.lastName, DTYPE = "Member", role = "Member", image_link = model.image_link };
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new tagContext()));
            if (!roleManager.RoleExists("Member"))
            {
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Member";
                roleManager.Create(Role);
            }
            tagContext ctx = new tagContext();
            var result = await _userManager.CreateAsync(User, model.Password);
            var role = _userManager.AddToRole(User.Id, "Member");
            //var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("G-Nation");
            //_userManager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<User>(provider.Create("EmailConfirmation"));
            //var token = await _userManager.GenerateEmailConfirmationTokenAsync(User.Id);
            //await _userManager.UserTokenProvider.GenerateAsync("Confirmation", _userManager, User);
            //await _userManager.UserTokenProvider.ValidateAsync("Confirmation", token, _userManager, User);

            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(User.Id);
            //var callbackUrl = Url.Action(
            //   "ConfirmEmail", "Account",
            //   new { userId = User.Id, code = code },
            //   protocol: Request.Url.Scheme);

            //await _userManager.SendEmailAsync(User.Id,
            //   "Confirm your account",
            //   "Please confirm your account by clicking this link: <a href=\""
            //                                   + callbackUrl + "\">link</a>");

            ctx.SaveChanges();


            return result;
        }
        public async Task<IdentityResult> RegisterExternalUser(RegisterViewModel model)
        {

            var User = new member { UserName = model.username, Email = model.Email, firstName = model.FirstName, lastName = model.lastName, DTYPE = "Member", role = "Member", image_link = model.image_link };
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new tagContext()));
            if (!roleManager.RoleExists("Member"))
            {
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Member";
                roleManager.Create(Role);
            }
            tagContext ctx = new tagContext();
            var result = await _userManager.CreateAsync(User);
            var role = _userManager.AddToRole(User.Id, "Member");
     

            ctx.SaveChanges();


            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public User FindClient(string clientId)
        {
            var client = _ctx.Users.Find(clientId);

            return client;
        }
        public User FindUser(string userName)
        {
            User client = _ctx.Users.Find(userName);

            return client;
        }

        public async Task<User> FindAsync(UserLoginInfo loginInfo)
        {
            User user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(User user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}