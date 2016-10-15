using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAG_DATA.Models;
using TAG_Domain.Entities;
using TAG_Service;
using TAG_Service.Interfaces;

namespace GUI.Controllers
{
    public class ArticleController : Controller
    {
        IArticleService artSer;
        public ArticleController(IArticleService artSer)
        {
            this.artSer = artSer;

        }

        // GET: Article
        public ActionResult Index()
        {
            //  var l = artSer.getAllArticles().ToList();

            return View();
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(article a)
        {

            if (ModelState.IsValid)
            {
                //  artSer.AddArticle(a);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }



        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult CreateGame(game g)
        {

            if (ModelState.IsValid)
            {
                // artSer.AddGames(g);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }



        }





        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Article/Edit/5
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

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Article/Delete/5
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
    }
}
