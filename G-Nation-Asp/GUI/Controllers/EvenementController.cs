using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUI.Models;
using TAG_Service.Interfaces;
using TAG_Domain.Entities;
using TAG_Service.Classes;
using Microsoft.AspNet.Identity;


namespace GUI.Controllers
{
    public class EvenementController : Controller
    {

        IEvenementService eventService = null;
        IAdminService userService = null;
        public EvenementController()
        {
            eventService = new EvenementService();
            userService = new AdminService();

        }
        // GET: Evenement
        public ActionResult Index()
        {
            var evenements = eventService.GetMany();
            List<EvenementModels> tVM = new List<EvenementModels>();
            foreach (var item in evenements)
            {
                User organizer = userService.GetById(item.organizer_idUser);
                System.Console.Write(organizer);
                EvenementModels t = new EvenementModels
                {
                    id_Evenement = item.id_Evenement,
                    description = item.description,
                    adresse = item.adresse,
                    name = item.name,
                    image_link = item.image_link,
                    nbrPlaces = item.nbrPlaces,
                    latitude = item.latitude,
                    longitude = item.longitude,
                    organizer_idUser = organizer.UserName

                };
                tVM.Add(t);
            }
            return View(tVM);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            evenement item = eventService.GetById(id);
            EvenementModels t = new EvenementModels
            {
                id_Evenement = item.id_Evenement,
                description = item.description,
                adresse = item.adresse,
                name = item.name,
                image_link = item.image_link,
                nbrPlaces = item.nbrPlaces,
                latitude = item.latitude,
                longitude = item.longitude,
                date=item.date,
                organizer_idUser=item.organizer_idUser,
                participants=item.participants,
                tournaments=item.tournaments,
                type=item.type,
                user=item.user
            };
            return View(t);
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            //var eventVM = new EvenementModels();
            List<evenement> events = eventService.GetMany().ToList();
            SelectList dropList = new SelectList(events, "id_Evenement", "name");
            ViewBag.dropList = dropList;
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(EvenementModels item, HttpPostedFileBase idFile)
        {
            try
            {
                if (ModelState.IsValid)
            {
                List<evenement> evenements = eventService.GetMany().ToList();
                SelectList dropList = new SelectList(evenements, "id_Evenement", "name");
                ViewBag.dropList = dropList;

                string uniqueName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                item.image_link = "img\\" + uniqueName;
                evenement t = new evenement()
                {
                    id_Evenement = item.id_Evenement,
                    description = item.description,
                    adresse = item.adresse,
                    name = item.name,
                    image_link = item.image_link,
                    nbrPlaces = item.nbrPlaces,
                    latitude = item.latitude,
                    longitude = item.longitude,
                    date = item.date,
                    organizer_idUser = User.Identity.GetUserId(),
                    type = item.type
                    
                };
                eventService.Add(t);

                return RedirectToAction("Index");
            }
            else

                return View();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            List<evenement> events = eventService.GetMany().ToList();
            SelectList dropList = new SelectList(events, "id_Evenement", "name");
            ViewBag.dropList = dropList;
            evenement item = new evenement();
            item = eventService.GetById(id);
            EvenementModels t = new EvenementModels()
            {
                id_Evenement = item.id_Evenement,
                description = item.description,
                adresse = item.adresse,
                name = item.name,
                image_link = item.image_link,
                nbrPlaces = item.nbrPlaces,
                latitude = item.latitude,
                longitude = item.longitude,
                date = item.date,
                organizer_idUser = item.organizer_idUser,
                participants = item.participants,
                tournaments = item.tournaments,
                type = item.type,
                user = item.user
            };
            return View(t);
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(EvenementModels item, HttpPostedFileBase idFile)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                item.image_link = "img\\" + uniqueName;
                evenement t = new evenement()
                {
                    id_Evenement = item.id_Evenement,
                    description = item.description,
                    adresse = item.adresse,
                    name = item.name,
                    image_link = item.image_link,
                    nbrPlaces = item.nbrPlaces,
                    latitude = item.latitude,
                    longitude = item.longitude,
                    date = item.date,
                    organizer_idUser = item.organizer_idUser,
                    participants = item.participants,
                    tournaments = item.tournaments,
                    type = item.type,
                    user = item.user
                };
                eventService.Update(t);
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {

            evenement item = new evenement();
            item = eventService.GetById(id);
            EvenementModels t = new EvenementModels()
            {
                id_Evenement = item.id_Evenement,
                description = item.description,
                adresse = item.adresse,
                name = item.name,
                image_link = item.image_link,
                nbrPlaces = item.nbrPlaces,
                latitude = item.latitude,
                longitude = item.longitude,
                date = item.date,
                organizer_idUser = item.organizer_idUser,
                participants = item.participants,
                tournaments = item.tournaments,
                type = item.type,
                user = item.user
            };
            return View(t);
        }


        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, evenement a)
        {
            if (ModelState.IsValid)
            {
                evenement b = eventService.GetById(id);

                eventService.Delete(b);
                return RedirectToAction("Index");

            }
            else
                return View();
        }
    }
}
