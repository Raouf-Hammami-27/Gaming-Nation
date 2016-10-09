using CrystalDecisions.CrystalReports.Engine;
using GUI.Models;
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
    public class ForumThController : Controller
    {
        IForumThService FoSer;
        ICommentService CmtSer;
        ForumViewModel fv = new ForumViewModel();
        public ForumThController()
        {
            FoSer = new ForumThService();
            CmtSer = new CommentService();
        }
        // GET: ForumTh
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //var l = FoSer.FindAllAsync();
            var l = await FoSer.GetAllAsync();
            return View(l);
        }

        // GET: ForumTh/Details/5
        public ActionResult Details(int id)
        {
            forumthread forum = FoSer.getById(id);
            return View(forum);
        }

        // GET: ForumTh/Create
        public ActionResult Create1()
        {
            return View();
        }

        // POST: ForumTh/Create
        [HttpPost]
        public ActionResult Create1(forumthread f, HttpPostedFileBase idFile)
        {
            if (ModelState.IsValid)
            {
                //f.idUser = 1;
                f.date=DateTime.Now;
                f.DTYPE = "f";
                string uniqueName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                f.link_imgg = "img\\" + uniqueName;
               
                FoSer.AddForumTh(f);
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
           forumthread forum = FoSer.getById(id);
            
            return View(new forumthread { description=forum.description,name=forum.name});

        }

        // POST: ForumTh/Edit/5
        [HttpPost]
        public ActionResult Edit(forumthread f,int id)
        {
            forumthread forum = FoSer.getById(id);
            try
            {


                if (ModelState.IsValid)
                {
                    forum.date =DateTime.Now;
                    forum.name = f.name;
                    forum.description = f.description;
                 
                    FoSer.Update(forum);

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
            forumthread forum = FoSer.getById(id);
            FoSer.Delete(forum);


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
        public async System.Threading.Tasks.Task<ActionResult> ListCmt(int id)
        {
            var cmt = await CmtSer.FindAllAsync(t => t.article.idArticle == id);
            //var cmt = CmtSer.getAllComment();
            return View(cmt);

        }

        public ActionResult DeleteCmt(int id)
        {
            commentaire cmt = CmtSer.getById(id);
            CmtSer.Delete(cmt);


            return RedirectToAction("ListCmt/"+id);
        }

        // POST: ForumTh/Delete/5
        [HttpPost]
        public ActionResult DeleteCmt(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListCmt/" + id);
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Create2()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create2(int id, commentaire c)
        {
            if (ModelState.IsValid)
            {
                IUsersService s1 = new UserService();
                forumthread forum = FoSer.getById(id);
                User us = s1.GetById(1);

                commentaire cmt = new commentaire { date = DateTime.Now, idArticle = forum.idArticle, description = c.description, idUser = us.Id };
                CmtSer.Add(cmt);

                return RedirectToAction("ListCmt/"+id);
            }
            else
            {
                return View();
            }
        }
        public ActionResult PieChart()
        {

            IForumThService s = new ForumThService();
            IUsersService s1 = new UserService();
            var nbusers = s1.GetMany().ToList();

            List<int> nbrForumTh = new List<int>();
            List<String> nameusers = new List<String>();
            foreach (User u in nbusers)

            {
                nbrForumTh.Add(s.CountForumTh(u.Id));
                nameusers.Add(u.firstName + u.lastName);
            }


            ViewBag.nbrForumTh = nbrForumTh;
            ViewBag.nbrusers = nameusers;
            // ViewBag.nbrHII = nbrHII;
            //  ViewBag.nbrHIII = nbrHIII;

            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        

    }
}
