using GUI.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TAG_DATA.Models;
using TAG_Domain.Entities;
using TAG_Service;
using TAG_Service.Classes;
using TAG_Service.Interfaces;

namespace GUI.Controllers
{
    public class GameController : Controller




    {
        IComments commSer = null;
        IGamesService artSer = null;
        IUsersService users = null;
        IArticleService arrticles = null;
        INewsService newws = null;
        IratingService rate = null;
        public GameController()
        {
            artSer = new ServiceGames();
            commSer = new comenttService();
            users = new UserService();
            arrticles = new ArticleService();
            newws = new NewsService();
            rate = new ratingService();

        }

        // GET: Game
        public ActionResult Index()
        {
            var games = artSer.GetMany();
            var articles = arrticles.GetMany();
            var newss = newws.GetMany();
            var Commentedgames = artSer.getMostCommented();
            var Rnkedgames = artSer.getBestRanked();


            List<gameViewModels> gVM = new List<gameViewModels>();
            foreach (var item in games)
            {
                gameViewModels gm = new gameViewModels()
                {
                    idArticle = item.idArticle,
                    DTYPE = item.DTYPE,
                    name = item.name,
                    description = item.description,
                    category = item.category,
                    link_img = item.link_img,
                    date = item.date,
                    rating = item.rating,
                };
                gVM.Add(gm);
            }
            ViewBag.Article = arrticles.GetMany().Count();
            ViewBag.games = artSer.GetMany().Count();
            ViewBag.news = newws.GetMany().Count();
            ViewBag.commgames = artSer.getMostCommented().Count();
            ViewBag.renkedGames= artSer.getBestRanked().Count();
            return View(gVM);

        }

        public async Task<ActionResult> getComment(int id)
        {    
           
          
          //  var comments = commSer.GetCommentsByArticle(id);
            var comms = await commSer.FindAllAsync(t => t.article.idArticle == id);
           
            List<CommentViewModels> gVM = new List<CommentViewModels>();
           
            foreach (var item in comms)
            {
               // var games = artSer.GetById(item.idArticle);
               // var name = games.name;
                CommentViewModels cm = new CommentViewModels()
                {
                    idArticle = item.idArticle,
                    idUser = item.idUser,
                    description = item.description,
                    date = item.date,
                    user=item.user,
                    article=item.article,
                    
                    

                };

                gVM.Add(cm);
            }
            return View(gVM);

        }



        public ActionResult getMostCommented()
        {
            var games = artSer.getMostCommented().ToArray();
            var TotalGames = artSer.GetMany().ToArray();
            
            
            var totalFund = artSer.GetMany().ToArray();
            var comm = commSer.getDateOfComm().ToArray();
           
          
            List<gameViewModels> gVM = new List<gameViewModels>();
            foreach (var item in games)
            {
                gameViewModels gm = new gameViewModels()
                {
                    idArticle = item.idArticle,
                    DTYPE = item.DTYPE,
                    name = item.name,
                    description = item.description,
                    link_img = item.link_img,
                    date = item.date,
                    commentts = item.commentts,
                    
                   
                };
                gVM.Add(gm);
               
            }
            

            CommentViewModels cm = new CommentViewModels();
            ViewBag.gmCount = games.Count();
            ViewBag.TotalCount = TotalGames.Count();
            ViewBag.notcommented = TotalGames.Count() - games.Count();
            ViewBag.usersComm = users.getUsersComments().Count();
            ViewBag.totalUsers = users.GetMany().Count();
            ViewBag.NonActiveUsers = users.GetMany().Count() - users.getUsersComments().Count();

            var comms1 = commSer.GetCommentsByMonth(1).ToArray();
            var comms2 = commSer.GetCommentsByMonth(2).ToArray();
            var comms3 = commSer.GetCommentsByMonth(3).ToArray();
            var comms4 = commSer.GetCommentsByMonth(4).ToArray();
            var comms5 = commSer.GetCommentsByMonth(5).ToArray();
            var comms6 = commSer.GetCommentsByMonth(6).ToArray();
            var comms7 = commSer.GetCommentsByMonth(7).ToArray();
            var comms8 = commSer.GetCommentsByMonth(8).ToArray();
            var comms9 = commSer.GetCommentsByMonth(9).ToArray();
            var comms10 = commSer.GetCommentsByMonth(10).ToArray();
            var comms11 = commSer.GetCommentsByMonth(11).ToArray();
            var comms12 = commSer.GetCommentsByMonth(12).ToArray();
            ViewBag.nbComm1 = comms1.Count();
            ViewBag.nbComm2 = comms2.Count();
            ViewBag.nbComm3 = comms3.Count();
            ViewBag.nbComm4 = comms4.Count();
            ViewBag.nbComm5 = comms5.Count();
            ViewBag.nbComm6 = comms6.Count();
            ViewBag.nbComm7 = comms7.Count();
            ViewBag.nbComm8 = comms8.Count();
            ViewBag.nbComm9 = comms9.Count();
            ViewBag.nbComm10 = comms10.Count();
            ViewBag.nbComm11 = comms11.Count();
            ViewBag.nbComm12 = comms12.Count();

           


            return View(gVM);

        }

        public ActionResult getBestRanked()
        {
            var games = artSer.getBestRanked();
            var ratedGames = artSer.RatedGames().Count();
            var totalGames = artSer.GetMany().Count();
            var totalRates = rate.GetMany().Count();


            List<gameViewModels> gVM = new List<gameViewModels>();
            foreach (var item in games)
            {
                gameViewModels gm = new gameViewModels()
                {
                    idArticle = item.idArticle,
                    DTYPE = item.DTYPE,
                    name = item.name,
                    rating=item.rating,
                    description = item.description,
                    link_img = item.link_img,
                    date = item.date,
                };
                gVM.Add(gm);
            }


            ViewBag.ratedGams = ratedGames;
            ViewBag.totalGames = totalGames;
            ViewBag.NoRatedGames = totalGames - ratedGames;
            ViewBag.totalrattess = totalRates;



            var comms1 = rate.GetNbrateMonth(1).ToArray();
            var comms2 = rate.GetNbrateMonth(2).ToArray();
            var comms3 = rate.GetNbrateMonth(3).ToArray();
            var comms4 = rate.GetNbrateMonth(4).ToArray();
            var comms5 = rate.GetNbrateMonth(5).ToArray();
            var comms6 = rate.GetNbrateMonth(6).ToArray();
            var comms7 = rate.GetNbrateMonth(7).ToArray();
            var comms8 = rate.GetNbrateMonth(8).ToArray();
            var comms9 = rate.GetNbrateMonth(9).ToArray();
            var comms10 = rate.GetNbrateMonth(10).ToArray();
            var comms11 = rate.GetNbrateMonth(11).ToArray();
            var comms12 = rate.GetNbrateMonth(12).ToArray();
            ViewBag.nbComm1 = comms1.Count();
            ViewBag.nbComm2 = comms2.Count();
            ViewBag.nbComm3 = comms3.Count();
            ViewBag.nbComm4 = comms4.Count();
            ViewBag.nbComm5 = comms5.Count();
            ViewBag.nbComm6 = comms6.Count();
            ViewBag.nbComm7 = comms7.Count();
            ViewBag.nbComm8 = comms8.Count();
            ViewBag.nbComm9 = comms9.Count();
            ViewBag.nbComm10 = comms10.Count();
            ViewBag.nbComm11 = comms11.Count();
            ViewBag.nbComm12 = comms12.Count();




            return View(gVM);

        }






        public ActionResult CustPrintOut()
        {
            // doing stuff
            return View("gameViewModels"); // return a view that renders your partials
        }

      
        public ActionResult printout( int id)
        {
            game g = new game();
            return new Rotativa.ActionAsPdf("Details", new { id = id })
            { 
                FileName = "gamesCatalogues.pdf"
            };
        }




        //public ActionResult PDF()
        //{



        //    return new ActionAsPdf("getMostCommented" , JavaScript("Scripts"));
        //}




        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
          
            game item = artSer.GetById(id);
           
            gameViewModels g = new gameViewModels()
            {

                idArticle=item.idArticle,
                name = item.name,
                date=item.date,
                description = item.description,
                category = item.category,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
                rating = item.rating,
                commentts=item.commentts,
                

            };
            return View(g);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(gameViewModels item, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
        {
            if (ModelState.IsValid)
            {

                //upload de l'image

                //   var path = Path.Combine(Server.MapPath("~/Content/img"), idFile.FileName);
                //  idFile.SaveAs(path);
                //  g.link_imgg = "img\\"+idFile.FileName;
                // g.link_img= "img\\" + idFilee.FileName;
                string uniqueName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));


                string uniqueNamee = Guid.NewGuid().ToString() +
                  System.IO.Path.GetExtension(idFilee.FileName);
                var uploadUrll = Server.MapPath("~/Content/img");

                idFilee.SaveAs(Path.Combine(uploadUrll, uniqueNamee));

                item.link_imgg = "img\\" + uniqueName;
                item.link_img = "img\\" + uniqueNamee;
                item.DTYPE = "game";
                item.date = DateTime.Now;
                item.rating = 0;
                // artSer.AddGames(g);

                game g = new game()
                {
                    idArticle = item.idArticle,
                    name = item.name,
                    description = item.description,
                    category = item.category,
                    link_imgg = item.link_imgg,
                    link_img = item.link_img,
                    DTYPE = item.DTYPE,
                    date = item.date,
                    rating = item.rating,

                };
                artSer.Add(g);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            game item = new game();
            item = artSer.GetById(id);
            gameViewModels g = new gameViewModels()
            {
                idArticle = item.idArticle,
                name = item.name,
                description = item.description,
                category = item.category,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
            };
            return View(g);
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(gameViewModels item, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
        {


            if (ModelState.IsValid)
            {
                
                item.date= DateTime.Now;
                game g = artSer.GetById(item.idArticle);



                g.name = item.name;
                g.description = item.description;
                g.category = item.category;
              
                g.date = item.date;

                artSer.Update(g);
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        public ActionResult EditPicture(int id)
        {
            game item = new game();
            item = artSer.GetById(id);
            gameViewModels g = new gameViewModels()
            {
                idArticle = item.idArticle,
                name = item.name,
                description = item.description,
                category = item.category,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
            };
            return View(g);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult EditPicture(gameViewModels item, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = Guid.NewGuid().ToString() +
            System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));




                var imgPath = "~/Content/img" + uniqueName;
                item.link_imgg = "img\\" + uniqueName;


                game g = artSer.GetById(item.idArticle);


                g.link_imgg = item.link_imgg;

                artSer.Update(g);
                return RedirectToAction("Edit", new { id = item.idArticle });
            }
            else
                return View();

        }

        public ActionResult EditCoverPicture(int id)
        {
            game item = new game();
            item = artSer.GetById(id);
            gameViewModels g = new gameViewModels()
            {
                idArticle = item.idArticle,
                name = item.name,
                description = item.description,
                category = item.category,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
            };
            return View(g);
        }

        [HttpPost]
        public ActionResult EditCoverPicture(newsViewModels itemm, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
        {
            if (ModelState.IsValid)
            {


                string uniqueName = Guid.NewGuid().ToString() +
                           System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));




                var imgPath = "~/Content/img" + uniqueName;
                itemm.link_img = "img\\" + uniqueName;

                game g = artSer.GetById(itemm.idArticle);

                g.link_img = itemm.link_img;


                artSer.Update(g);
                return RedirectToAction("Edit", new { id = itemm.idArticle });
            }
            else
                return View();

        }








        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            game item = new game();
            item = artSer.GetById(id);
            gameViewModels g = new gameViewModels()
            {
                idArticle = item.idArticle,
                DTYPE = item.DTYPE,
                name = item.name,
                description = item.description,
                category = item.category,
                link_img = item.link_img,
                date = item.date,
                rating = item.rating,
            }; return View(g);
        }

        // POST: Game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, game a)
        {
            if (ModelState.IsValid)
            {
                game b = artSer.GetById(id);

                artSer.Delete(b);
                return RedirectToAction("Index");

            }
            else
                return View();

        }


        // GET: Comment/Delete/5
        public ActionResult DeleteComm(int id, string idUser , DateTime date)
        {
            commentt item = new commentt();
            item = commSer.Get(t => t.article.idArticle == id && t.idUser.Equals(idUser) && t.date==date);
            CommentViewModels g = new CommentViewModels()
            {
                idArticle = item.idArticle,
                idUser = item.idUser,
                description = item.description,
                date = item.date,
               
            }; return View(g);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult DeleteComm(int id, string idUser, DateTime date, commentt c)
        {
            if (ModelState.IsValid)
            {
                commentt b = commSer.Get(t => t.article.idArticle == id && t.idUser.Equals(idUser) && t.date == date);

                commSer.Delete(b);
                return RedirectToAction("Details", new { id = b.idArticle });
            }
            else
                return View();
        }




    }
}
