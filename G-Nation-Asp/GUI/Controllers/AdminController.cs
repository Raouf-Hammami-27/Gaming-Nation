using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TAG_Service.Classes;
using TAG_Service.Interfaces;
using GUI.Models;
using TAG_Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TAG_DATA.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.IO;
using System;

namespace GUI.Controllers
{
    public class AdminController : Controller
    {
        IAdminService adminService = null;
        public AdminController()
        {
            adminService = new AdminService();

        }
        // GET: Admin
        public ActionResult Index()
        { 
           
            return View();
        }
        public ActionResult Index_Member()
        {
            var crew = adminService.GetMany();
            List<AddCrewViewModel> users = new List<AddCrewViewModel>();
            foreach (var item in crew.Where(i=>i.role=="Member"))
            {
                AddCrewViewModel org = new AddCrewViewModel
                {
                    Id = item.Id,
                    username = item.UserName,
                    Email = item.Email,
                    lastName = item.lastName,
                    FirstName = item.firstName,
                    role = item.role,


                };
                users.Add(org);
            }
            return View(users);
        }
        public ActionResult Index_Event_Organizer()
        {
            var crew = adminService.GetMany();
            List<AddCrewViewModel> users = new List<AddCrewViewModel>();
            foreach (var item in crew.Where(i => i.role == "Event_Organizer"))
            {
                AddCrewViewModel org = new AddCrewViewModel
                {
                    Id = item.Id,
                    username = item.UserName,
                    Email = item.Email,
                    lastName = item.lastName,
                    FirstName = item.firstName,
                    role = item.role,


                };
                users.Add(org);
            }
            return View(users);
        }
        public ActionResult Index_Vip()
        {
            var crew = adminService.GetMany();
            List<AddCrewViewModel> users = new List<AddCrewViewModel>();
            foreach (var item in crew.Where(i => i.role == "Vip"))

            {
                AddCrewViewModel org = new AddCrewViewModel
                {
                    Id = item.Id,
                    username = item.UserName,
                    Email = item.Email,
                    lastName = item.lastName,
                    FirstName = item.firstName,
                    role = item.role,


                };
                users.Add(org);
            }
            return View(users);
        }
        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            User item = adminService.GetById(id);
            AddCrewViewModel t = new AddCrewViewModel
            {
                Id = item.Id,
                username = item.UserName,
                Email = item.Email,
                lastName = item.lastName,
                FirstName = item.firstName,
                role = item.role
            };
            return View(t);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            //List<User> organizers = adminService.GetMany().ToList();
            //SelectList dropList = new SelectList(organizers, "id_Organizer", "Username");
            //ViewBag.dropList = dropList;
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
       // [Authorize(Roles ="Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddCrewViewModel model, HttpPostedFileBase idFile)
        {
            if (ModelState.IsValid)
            {
                
                tagContext ctx = new tagContext();
                string link = Guid.NewGuid().ToString() +
              System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");
                idFile.SaveAs(Path.Combine(uploadUrl, link));
                model.image_link = "img\\" + link;
                var User = new User() {  UserName = model.username, Email = model.Email, firstName = model.FirstName, lastName = model.lastName, DTYPE = "Event_Organizer", role = "Event_Organizer",image_link= model.image_link };
                var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new tagContext()));
                if (!roleManager.RoleExists("Event_Organizer"))
                {
                    var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    Role.Name = "Event_Organizer";
                    roleManager.Create(Role);
                }
                var result = await UserManager.CreateAsync(User, model.Password);
                var id = User.Id;
                System.Console.WriteLine(id);
               var role = UserManager.AddToRole(id, "Event_Organizer");
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
                return RedirectToAction("Index_Event_Organizer");
            }
            else
                return View();

        
    }

        public ActionResult Statistics()
        {
            ViewBag.membersCount = adminService.membersStats();
            ViewBag.vipsCount = adminService.vipStats();
            ViewBag.images = adminService.imagesuploadedStats();
            ViewBag.GoogleMembers = adminService.googleStats();
            ViewBag.FacebookMembers = adminService.facebookStats();
            return this.View();
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]

        public async Task<ActionResult> Edit( AddCrewViewModel b, string id)
        {

            var user = await UserManager.FindByIdAsync(id);
            await UserManager.IsLockedOutAsync(user.Id);
            await UserManager.SetLockoutEnabledAsync(user.Id, true);
            await UserManager.SetLockoutEndDateAsync(user.Id, DateTime.Today.AddDays(3));
            user.ban = true;

            return RedirectToAction("Index_Member");
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            User item = adminService.GetById(id);
            AddCrewViewModel t = new AddCrewViewModel
            {
                Id = item.Id,
                username = item.UserName,
                Email = item.Email,
                lastName = item.lastName,
                FirstName = item.firstName,
                role = item.role
            };
            return View(t);
        }

        // POST: Admin/Delete/5
        [HttpPost]
       // [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id, User b)
        {

            if (ModelState.IsValid)
            {
                 User a = adminService.GetById(id);
                adminService.Delete(a);
                return RedirectToAction("Index");

            }
            else
                return View();
        }
    
        private ApplicationUserManager _userManager;

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
    }
}
