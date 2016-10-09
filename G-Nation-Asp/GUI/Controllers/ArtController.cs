using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ArtController : Controller
    {
        // GET: Art
        public ActionResult Index()
        {
            return View();
        }

        // GET: Art/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Art/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Art/Create
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

        // GET: Art/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Art/Edit/5
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

        // GET: Art/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Art/Delete/5
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
