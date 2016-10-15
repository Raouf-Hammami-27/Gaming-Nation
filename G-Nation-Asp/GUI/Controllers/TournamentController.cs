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
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controllers
{
    public class TournamentController : Controller
    {

        ITournamentService tournamentService=null;
        IEvenementService eventService=null;
        public TournamentController()
        {
            tournamentService = new TournamentService();
            eventService = new EvenementService();

        }
        // GET: Evenement
        public ActionResult Index()
        {

            var tournaments = tournamentService.GetMany();
            List<TournamentModels> tVM = new List<TournamentModels>();
            foreach (var item in tournaments)
            {
                TournamentModels t = new TournamentModels
                {
                    id_tournament = item.id_tournament,
                    description = item.description,
                    adresse = item.adresse,
                    name = item.name,
                    image_link = item.image_link,
                    nbrPlaces = item.nbrPlaces,
                    broadcast_link = item.broadcast_link,
                    latitude = item.latitude,
                    longitude = item.longitude,
                    evenement_id_Evenement = item.evenement_id_Evenement,
                    url = item.url
                };
                tVM.Add(t);
            }
            return View(tVM);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            tournament item = tournamentService.GetById(id);
            TournamentModels t = new TournamentModels
            {
                id_tournament = item.id_tournament,
                description = item.description,
                adresse = item.adresse,
                name = item.name,
                image_link = item.image_link,
                nbrPlaces = item.nbrPlaces,
                broadcast_link = item.broadcast_link,
                latitude = item.latitude,
                longitude = item.longitude,
                evenement = item.evenement,
                evenement_id_Evenement = item.evenement_id_Evenement,
                url=item.url
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
        public async Task<ActionResult> Create(TournamentModels item, HttpPostedFileBase idFile)
        {

            try
            {

                if (ModelState.IsValid)
                {


                    #region connection
                    Uri uri = new Uri("https://challonge.com/api/tournaments.json");

                    List<evenement> evenements = eventService.GetMany().ToList();
                    SelectList dropList = new SelectList(evenements, "id_Evenement", "name");
                    ViewBag.dropList = dropList;

                    string uniqueName = Guid.NewGuid().ToString() +
                        System.IO.Path.GetExtension(idFile.FileName);
                    var uploadUrl = Server.MapPath("~/Content/img");

                    idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                    item.image_link = "img\\" + uniqueName;
                    tournament t = new tournament()
                    {
                        id_tournament = item.id_tournament,
                        description = item.description,
                        adresse = item.adresse,
                        name = item.name,
                        image_link = item.image_link,
                        nbrPlaces = item.nbrPlaces,
                        broadcast_link = item.broadcast_link,
                        latitude = item.latitude,
                        longitude = item.longitude,
                        evenement = item.evenement,
                        evenement_id_Evenement = item.evenement_id_Evenement,
                        participanttournaments = item.participanttournaments,
                        url =  "GNation"+item.name
                    };


                    //Create an Http client and set the headers we want
                    HttpClient aClient = new HttpClient();
                    var byteArray = Encoding.ASCII.GetBytes("mhaasif1:futMbBLufRuMKaxsIpBhaMxhaevOXsz1JBmH2liV");
                    aClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    aClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    aClient.DefaultRequestHeaders.Host = uri.Host;

                    //Create a Json Serializer for our type
                    JsonSerializer jsonSer = JsonSerializer.CreateDefault();

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://challonge.com/api/tournaments.json");
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "POST";

                    #endregion

                    using (var sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            #region Serialize
                            jsonSer.Serialize(writer, t);

                            string json = JsonConvert.SerializeObject(t);
                            JObject jObj = JObject.Parse(json);
                            jObj.Property("id_tournament").Remove();
                            jObj.Property("description").Remove();
                            jObj.Property("adresse").Remove();
                            jObj.Property("image_link").Remove();
                            jObj.Property("nbrPlaces").Remove();
                            jObj.Property("broadcast_link").Remove();
                            jObj.Property("latitude").Remove();
                            jObj.Property("longitude").Remove();
                            jObj.Property("evenement").Remove();
                            jObj.Property("evenement_id_Evenement").Remove();
                            jObj.Property("participanttournaments").Remove();
                            string output = JsonConvert.SerializeObject(jObj);
                            StringContent theContent = new StringContent(output, Encoding.UTF8, "application/json");
                            #endregion

                            //Post the data
                            HttpResponseMessage aResponse = await aClient.PostAsync(uri, theContent);
                            System.Diagnostics.Debug.WriteLine(aResponse.ToString());
                            if (aResponse.IsSuccessStatusCode)
                            {
                                tournamentService.Add(t);
                            }

                            else
                            {
                                // show the response status code
                                String failureMsg = "HTTP Status: " + aResponse.StatusCode.ToString() + " - Reason: " + aResponse.ReasonPhrase;
                                System.Diagnostics.Debug.WriteLine(failureMsg);

                            }
                        }


                    }
                }
                return RedirectToAction("Index");


            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);

                return View();
            }
            
        }
            

        

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            List<evenement> events = eventService.GetMany().ToList();
            SelectList dropList = new SelectList(events, "id_Evenement", "name");
            ViewBag.dropList = dropList;
            tournament item = new tournament();
             item=tournamentService.GetById(id);
            TournamentModels t = new TournamentModels()
            {
                id_tournament = item.id_tournament,
                description = item.description,
                adresse = item.adresse,
                name = item.name,
                image_link = item.image_link,
                nbrPlaces = item.nbrPlaces,
                broadcast_link = item.broadcast_link,
                latitude = item.latitude,
                longitude = item.longitude,
                evenement = item.evenement,
                evenement_id_Evenement = item.evenement_id_Evenement,
                participanttournaments = item.participanttournaments
            };
            return View(t);
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(TournamentModels item, HttpPostedFileBase idFile)
        {
            if (ModelState.IsValid)
            { 
                string uniqueName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                item.image_link = "img\\" + uniqueName;
                tournament t = new tournament()
                {
                    id_tournament = item.id_tournament,
                    description = item.description,
                    adresse = item.adresse,
                    name = item.name,
                    image_link = item.image_link,
                    nbrPlaces = item.nbrPlaces,
                    broadcast_link = item.broadcast_link,
                    latitude = item.latitude,
                    longitude = item.longitude,
                    evenement = item.evenement,
                    evenement_id_Evenement = item.evenement_id_Evenement,
                    participanttournaments = item.participanttournaments,
                    url=item.url
                };
                tournamentService.Update(t);
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {

            tournament item = new tournament();
            item = tournamentService.GetById(id);

            TournamentModels t = new TournamentModels()
            {
                id_tournament = item.id_tournament,
                description = item.description,
                adresse = item.adresse,
                name = item.name,
                image_link = item.image_link,
                nbrPlaces = item.nbrPlaces,
                broadcast_link = item.broadcast_link,
                latitude = item.latitude,
                longitude = item.longitude,
                evenement = item.evenement,
                evenement_id_Evenement = item.evenement_id_Evenement,
                participanttournaments = item.participanttournaments
            }; return View(t);
        }


        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tournament a)
        {
            if (ModelState.IsValid)
            {
                tournament b = tournamentService.GetById(id);

                tournamentService.Delete(b);
                return RedirectToAction("Index");

            }
            else
                return View();
        }

        // POST: Participants/Create
        [HttpPost]
        public async Task<ActionResult> AddParticipant(tournament p, string participant)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    #region connection
                    Uri uri = new Uri("https://challonge.com/api/tournaments/" + p.name + "/participants.json");

                    //Create an Http client and set the headers we want
                    HttpClient aClient = new HttpClient();
                    var byteArray = Encoding.ASCII.GetBytes("pendow:6y6NWIz0eeYahOfWddiWB63MGuHvlAcTxzrhJLwv");
                    aClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    aClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    aClient.DefaultRequestHeaders.Host = uri.Host;

                    //Create a Json Serializer for our type
                    JsonSerializer jsonSer = JsonSerializer.CreateDefault();

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri.ToString());
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "POST";

                    #endregion

                    using (var sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            #region Serialize
                            jsonSer.Serialize(writer, p);

                            string json = JsonConvert.SerializeObject(p);
                            JObject jObj = JObject.Parse(json);

                            jObj.Property("name").Remove();
                            jObj.Property("name").Add(participant);
                            jObj.Property("id_tournament").Remove();
                            jObj.Property("description").Remove();
                            jObj.Property("adresse").Remove();
                            jObj.Property("image_link").Remove();
                            jObj.Property("nbrPlaces").Remove();
                            jObj.Property("broadcast_link").Remove();
                            jObj.Property("latitude").Remove();
                            jObj.Property("longitude").Remove();
                            jObj.Property("evenement").Remove();
                            jObj.Property("evenement_id_Evenement").Remove();
                            jObj.Property("participanttournaments").Remove();
                            jObj.Property("url").Remove();
                            string output = JsonConvert.SerializeObject(jObj);
                            StringContent theContent = new StringContent(output, Encoding.UTF8, "application/json");
                            #endregion

                            //Post the data
                            HttpResponseMessage aResponse = await aClient.PostAsync(uri, theContent);

                            if (aResponse.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Edit", new { id = p.id_tournament });

                            }

                            else
                            {
                                // show the response status code
                                String failureMsg = "HTTP Status: " + aResponse.StatusCode.ToString() + " - Reason: " + aResponse.ReasonPhrase;
                            }
                        }

                    }
                }

                return RedirectToAction("Edit", new { id = p.id_tournament });
            }
            catch
            {
                return View();
            }
        }

    }
}
