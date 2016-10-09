using GUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TAG_Domain.Entities;
using TAG_Service;
using TAG_Service.Classes;
using TAG_Service.Interfaces;

namespace GUI.Controllers
{
    public class NewsController : Controller
    {
        IComments commSer = null;

        INewsService artSer =null;
        IArticleService arrticles = null;
        IGamesService artgamesSer = null;
        IUsersService users = null;


        public NewsController()
        {
           artSer= new NewsService() ;
            arrticles = new ArticleService();
            artgamesSer = new ServiceGames();
            commSer = new comenttService();
            users = new UserService();



        }

        // GET: News
        public ActionResult Index()
        {
            var news = artSer.GetMany();
            var games = artgamesSer.GetMany();
            var articles = arrticles.GetMany();
            var Commentednews = artSer.getMostCommented();


            List<newsViewModels> gVM = new List<newsViewModels>();
            foreach (var item in news)
            {
                newsViewModels gm = new newsViewModels()
                {
                    idArticle = item.idArticle,
                    DTYPE = item.DTYPE,
                    name = item.name,
                    description = item.description,
                    link_img = item.link_img,
                    date = item.date,
                };
                gVM.Add(gm);
            }

            ViewBag.Article = arrticles.GetMany().Count();
            ViewBag.games = artgamesSer.GetMany().Count();
            ViewBag.news = artSer.GetMany().Count();
            ViewBag.commnewss = artSer.getMostCommented().Count();



            return View(gVM);
        }



        public ActionResult getMostCommented()
        {
            var news = artSer.getMostCommented().ToArray();
            var TotalGames = artSer.GetMany().ToArray();
            var comm = commSer.getDateOfComm().ToArray();


            var totalFund = artSer.GetMany().ToArray();

            // var totalFund = artSer.GetMany().ToArray();
            // var comm = commSer.getDateOfComm().ToArray();


            List<newsViewModels> gVM = new List<newsViewModels>();
            foreach (var item in news)
            {
                newsViewModels gm = new newsViewModels()
                {
                    idArticle = item.idArticle,
                    DTYPE = item.DTYPE,
                    name = item.name,
                    description = item.description,
                    link_img = item.link_img,
                    date = item.date,
                    commentts = item.commentts,


                };

                ViewBag.newsCount = news.Count();
                ViewBag.TotalCount = TotalGames.Count();
                ViewBag.notcommented = TotalGames.Count() - news.Count();

                ViewBag.usersComm = users.getUsersComments().Count();
                ViewBag.totalUsers = users.GetMany().Count();
                ViewBag.NonActiveUsers = users.GetMany().Count() - users.getUsersComments().Count();


                var comms1 = commSer.GetCommentsNewsByMonth(1).ToArray();
                var comms2 = commSer.GetCommentsNewsByMonth(2).ToArray();
                var comms3 = commSer.GetCommentsNewsByMonth(3).ToArray();
                var comms4 = commSer.GetCommentsNewsByMonth(4).ToArray();
                var comms5 = commSer.GetCommentsNewsByMonth(5).ToArray();
                var comms6 = commSer.GetCommentsNewsByMonth(6).ToArray();
                var comms7 = commSer.GetCommentsNewsByMonth(7).ToArray();
                var comms8 = commSer.GetCommentsNewsByMonth(8).ToArray();
                var comms9 = commSer.GetCommentsNewsByMonth(9).ToArray();
                var comms10 = commSer.GetCommentsNewsByMonth(10).ToArray();
                var comms11 = commSer.GetCommentsNewsByMonth(11).ToArray();
                var comms12 = commSer.GetCommentsNewsByMonth(12).ToArray();
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




                gVM.Add(gm);

            }


            //CommentViewModels cm = new CommentViewModels();
            //ViewBag.gmCount = games.Count();
            //ViewBag.TotalCount = TotalGames.Count();
            //ViewBag.notcommented = TotalGames.Count() - games.Count();
            //ViewBag.usersComm = users.getUsersComments().Count();
            //ViewBag.totalUsers = users.GetMany().Count();
            //ViewBag.NonActiveUsers = users.GetMany().Count() - users.getUsersComments().Count();

            //var comms1 = commSer.GetCommentsByMonth(1).ToArray();
            //var comms2 = commSer.GetCommentsByMonth(2).ToArray();
            //var comms3 = commSer.GetCommentsByMonth(3).ToArray();
            //var comms4 = commSer.GetCommentsByMonth(4).ToArray();
            //var comms5 = commSer.GetCommentsByMonth(5).ToArray();
            //var comms6 = commSer.GetCommentsByMonth(6).ToArray();
            //var comms7 = commSer.GetCommentsByMonth(7).ToArray();
            //var comms8 = commSer.GetCommentsByMonth(8).ToArray();
            //var comms9 = commSer.GetCommentsByMonth(9).ToArray();
            //var comms10 = commSer.GetCommentsByMonth(10).ToArray();
            //var comms11 = commSer.GetCommentsByMonth(11).ToArray();
            //var comms12 = commSer.GetCommentsByMonth(12).ToArray();
            //ViewBag.nbComm1 = comms1.Count();
            //ViewBag.nbComm2 = comms2.Count();
            //ViewBag.nbComm3 = comms3.Count();
            //ViewBag.nbComm4 = comms4.Count();
            //ViewBag.nbComm5 = comms5.Count();
            //ViewBag.nbComm6 = comms6.Count();
            //ViewBag.nbComm7 = comms7.Count();
            //ViewBag.nbComm8 = comms8.Count();
            //ViewBag.nbComm9 = comms9.Count();
            //ViewBag.nbComm10 = comms10.Count();
            //ViewBag.nbComm11 = comms11.Count();
            //ViewBag.nbComm12 = comms12.Count();




            return View(gVM);

        }


        public ActionResult CustPrintOut()
        {
            // doing stuff
            return View("newsViewModels"); // return a view that renders your partials
        }


        public ActionResult printout(int id)
        {
            game g = new game();
            return new Rotativa.ActionAsPdf("Details", new { id = id })
            {
                FileName = "NewsCatalogues.pdf"
            };
        }




        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            news item = artSer.GetById(id);
            newsViewModels g = new newsViewModels()
            {

                idArticle=item.idArticle,
                name = item.name,
                date=item.date,
                description = item.description,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
                commentts = item.commentts,
            };
            return View(g);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(newsViewModels item, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
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
                item.DTYPE = "news";
                item.date = DateTime.UtcNow;
                // artSer.AddGames(g);

                news n = new news()
                {
                    idArticle = item.idArticle,
                    name = item.name,
                    description = item.description,
                    link_imgg = item.link_imgg,
                    link_img = item.link_img,
                    DTYPE = item.DTYPE,
                    date = item.date,
                   

                };
                artSer.Add(n);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            news item = new news();
            item = artSer.GetById(id);
            newsViewModels g = new newsViewModels()
            {
                idArticle = item.idArticle,
                name = item.name,
                description = item.description,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
            };
            return View(g);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(newsViewModels item, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
        {
            if (ModelState.IsValid)
            {

                item.date = DateTime.Now;
                news g = artSer.GetById(item.idArticle);



                g.name = item.name;
                g.description = item.description;

                g.date = item.date;
                artSer.Update(g);
                return RedirectToAction("Index");
            }
            else
                return View();

        }



        public ActionResult EditPicture(int id)
        {
            news item = new news();
            item = artSer.GetById(id);
            newsViewModels g = new newsViewModels()
            {
                idArticle = item.idArticle,
                link_img = item.link_img,
                link_imgg = item.link_imgg,
            };
            return View(g);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult EditPicture(newsViewModels item, HttpPostedFileBase idFile, HttpPostedFileBase idFilee)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = Guid.NewGuid().ToString() +
            System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));


                

                var imgPath= "~/Content/img" + uniqueName;
                item.link_imgg = "img\\" + uniqueName;
               

                news g = artSer.GetById(item.idArticle);

               
                g.link_imgg = item.link_imgg;

                artSer.Update(g);
                return RedirectToAction("Edit", new { id = item.idArticle });
            }
            else
                return View();

        }

        public ActionResult EditCoverPicture(int id)
        {
            news itemm = new news();
            itemm = artSer.GetById(id);
            newsViewModels g1 = new newsViewModels()
            {
                idArticle = itemm.idArticle,
                link_img = itemm.link_img,
                link_imgg = itemm.link_imgg,
            };
            return View(g1);
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

                news g = artSer.GetById(itemm.idArticle);

                g.link_img = itemm.link_img;
               

                artSer.Update(g);
                return RedirectToAction("Edit", new { id = itemm.idArticle });
            }
            else
                return View();

        }





        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            news item = new news();
            item = artSer.GetById(id);
            newsViewModels g = new newsViewModels()
            {
                idArticle = item.idArticle,
                DTYPE = item.DTYPE,
                name = item.name,
                description = item.description,
                link_img = item.link_img,
                date = item.date,
            }; return View(g);
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, news n)
        {
            if (ModelState.IsValid)
            {
                news b = artSer.GetById(id);

                artSer.Delete(b);
                return RedirectToAction("Index");

            }
            else
                return View();

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
                    user = item.user,
                    article = item.article,



                };

                gVM.Add(cm);
            }
            return View(gVM);

        }




        // GET: Comment/Delete/5
        public ActionResult DeleteComm(int id, string idUser, DateTime date)
        {
            commentt item = new commentt();
            item = commSer.Get(t => t.article.idArticle == id && t.idUser.Equals(idUser) && t.date == date);
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
