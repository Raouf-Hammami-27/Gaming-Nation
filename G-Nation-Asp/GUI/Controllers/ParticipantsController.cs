using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAG_Service.Classes;
using TAG_Service.Interfaces;

namespace GUI.Controllers
{
    public class ParticipantsController : Controller
    {
        IParticipantsService participantsService = null;
        ITournamentService tournamentService = null;
        ParticipantsController()
        {
            IParticipantsService participantsService = new ParticipantsService();
            ITournamentService tournamentService = new TournamentService();
        }
        // GET: Participants
        public ActionResult Index()
        {
            var participants = participantsService.GetMany();
            List<ParticipantsModels> pVM = new List<ParticipantsModels>();
            foreach (var item in participants)
            {
                ParticipantsModels t = new ParticipantsModels
                {
                    idEvent = item.idEvent,
                    idParticipant = item.idParticipant,
                    date_limite = item.date_limite,
                    idTournament = item.idTournament,
                    tournament=item.tournament,
                    user=item.user
                };
                pVM.Add(t);
            }
            return View(pVM);
        }

        // GET: Participants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participants/Create
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

        // GET: Participants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Participants/Edit/5
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

        // GET: Participants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Participants/Delete/5
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
