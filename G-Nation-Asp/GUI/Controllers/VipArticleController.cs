using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAG_DATA.Models;
using TAG_Domain.Entities;
using TAG_Service.Classes;
using TAG_Service;
using TAG_Service.Interfaces;


namespace GUI.Controllers
{
    public class VipArticleController : Controller
    {
        IVipArticleService VipSer;

        public VipArticleController()
        {
            VipSer = new VipArticleService();
        }
        // GET: ForumTh
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //var l = FoSer.FindAllAsync();
            var l = await VipSer.GetAllAsync();
            return View(l);
        }

        // GET: ForumTh/Details/5
        public ActionResult Details(int id)
        {
            vipArticle forum = VipSer.getById(id);
            return View(forum);
        }

        // GET: ForumTh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumTh/Create
        [HttpPost]
        public ActionResult Create(vipArticle v, HttpPostedFileBase idFile)
        {
            if (ModelState.IsValid)
            {
                //f.idUser = 1;
                v.date = DateTime.Now;
                v.DTYPE = "v";

                string uniqueName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                v.link_imgg = "img\\" + uniqueName;

                VipSer.Add(v);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: ForumTh/Edit/5
        public ActionResult Edit(int id)
        {
            IUsersService s1 = new UserService();
            vipArticle vipA = VipSer.getById(id);

            User us = s1.GetById("a9c06e9e-5386-4863-bd37-3e88b5510da7");
            return View(new vipArticle { date=DateTime.Now,description = vipA.description, name = vipA.name, idUser = us.Id });

        }

        // POST: ForumTh/Edit/5
        [HttpPost]
        public ActionResult Edit(vipArticle v, int id)
        {
            vipArticle vipA = VipSer.getById(id);
            try
            {


                if (ModelState.IsValid)
                {
                    vipA.date = DateTime.Now;
                    vipA.name = v.name;
                    vipA.description = v.description;
                    vipA.idVip = v.idVip;
                    VipSer.Update(vipA);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ForumTh/Delete/5
        public ActionResult Delete(int id)
        {
            vipArticle vipA = VipSer.getById(id);
            VipSer.Delete(vipA);


            return RedirectToAction("Index");
        }

        // POST: ForumTh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult WeatherJS()
        {
            return View();
        }

    }
        
}
