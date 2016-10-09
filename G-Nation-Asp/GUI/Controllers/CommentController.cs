using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAG_Domain.Entities;
using TAG_Service.Classes;
using TAG_Service.Interfaces;

namespace GUI.Controllers
{
    public class CommentController : Controller
    {
        IComments commSer = null;
        public CommentController()
        {
            commSer = new comenttService();
        }


        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult DeleteComm(int id)
        {
            commentt item = new commentt();
            item =  commSer.GetById(id);
            CommentViewModels g = new CommentViewModels()
            {
                idArticle = item.idArticle,
                idUser = item.idUser,
                description = item.description,
                date = item.date,
                user = item.user,
                article = item.article,
            }; return View(g);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult DeleteComm(int id, commentt c)
        {
            if (ModelState.IsValid)
            {
                commentt b = commSer.GetById(id);

                commSer.Delete(b);
                return RedirectToAction("getComment");

            }
            else
                return View();
        }
    }
}
