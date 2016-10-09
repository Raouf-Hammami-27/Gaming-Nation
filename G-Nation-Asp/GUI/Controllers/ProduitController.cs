using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TAG_Domain.Entities;
using TAG_Service.Classes;
using TAG_Service;
using TAG_Service.Interfaces;


namespace GUI.Controllers
{
    public class ProduitController : Controller
    {
        IProduitService prSer;
        IPannierService panSer;

        public ProduitController(IProduitService pr)
        {
            prSer = new ProduitService();
            panSer = new PannierService();


        }
        // GET: ForumTh
        public ActionResult Index()
        {
            var l = prSer.getAllProduits().ToList();
            return View(l);
        }

        // GET: ForumTh/Details/5
        public ActionResult Details(int id)
        {
            produit forum = prSer.getById(id);
            return View(forum);
        }

        // GET: ForumTh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumTh/Create
        [HttpPost]
        public ActionResult Create(produit f,HttpPostedFileBase idFile)
        {
            if (ModelState.IsValid)
            {
                //f.idUser = 1;
                f.date = DateTime.Now;
                string uniqueName = Guid.NewGuid().ToString() +
                   System.IO.Path.GetExtension(idFile.FileName);
                var uploadUrl = Server.MapPath("~/Content/img");

                idFile.SaveAs(Path.Combine(uploadUrl, uniqueName));

                f.image_link = "img\\" + uniqueName;
                prSer.AddProduit(f);
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
            produit produits = prSer.getById(id);

            return View(new produit { description = produits.description, name = produits.name, price = produits.price, quantite = produits.quantite });

        }

        // POST: ForumTh/Edit/5
        [HttpPost]
        public ActionResult Edit(produit f, int id)
        {
            produit produits = prSer.getById(id);
            try
            {


                if (ModelState.IsValid)
                {
                    produits.date = DateTime.Now;
                    produits.name = f.name;
                    produits.description = f.description;
                    produits.price = f.price;
                    produits.quantite = f.quantite;

                    prSer.Update(produits);

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
            produit produits = prSer.getById(id);
            //if (req == null) return HttpNotFound();
            prSer.Delete(produits);


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
        // GET: pannier/add
        
        public ActionResult AddProduct(int id,pannier p)
        {
            if (ModelState.IsValid)
            {
                IUsersService s1 = new UserService();
                produit produits = prSer.getById(id);
                User us = s1.GetById("a9c06e9e-5386-4863-bd37-3e88b5510da7");
                pannier pann = new pannier { date = DateTime.Now, idProduit = produits.idProduit ,idUser=us.Id};
                panSer.Add(pann);

                return RedirectToAction("ListPannier/"+id);
            }
            else
            {
                return View();
            }

            // POST: ForumTh/Create

        }
        public ActionResult ListPannier()
        {
            var l = panSer.getAllPannier().ToList();
            return View(l);
        }

        public ActionResult PieChartProduit()
        {
            IProduitService s = new ProduitService();
            IUsersService s1 = new UserService();
            var nbusers = s1.GetMany().ToList();

            List<int> nbrProduit = new List<int>();
            List<String> nameusers = new List<String>();
            foreach (User u in nbusers)

            {
                nbrProduit.Add(s.CountProduit(u.Id));
                nameusers.Add(u.firstName + u.lastName);
            }


            ViewBag.nbrProduit = nbrProduit;
            ViewBag.nbrusers = nameusers;
            // ViewBag.nbrHII = nbrHII;
            //  ViewBag.nbrHIII = nbrHIII;

            return View();
        }
        public ActionResult DeletePann(int id)
        {
            pannier pan = panSer.getById(id);
            panSer.Delete(pan);


            return RedirectToAction("ListPannier/" + id);
        }

        // POST: ForumTh/Delete/5
        [HttpPost]
        public ActionResult DeleteCmt(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListPannier/" + id);
            }
            catch
            {
                return View();
            }
        }
        public void pdf()
        {
            
                Document pdfDoc = new Document(PageSize.A4, 0, 0, 0, 0);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                using (MemoryStream stream = new MemoryStream())
                {
                    
                    pdfDoc.NewPage();
                foreach (produit mr in prSer.getAllProduits())
                {
                    Paragraph para = new Paragraph("Product :"+mr.idProduit+"\n" +mr.description);
                    pdfDoc.Add(para);
                }
                

                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    //string nom = ("/") + ("Product.pdf");
                    // Response.AddHeader("content-disposition", "attachment;filename=" + nom);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
              
            }
        }

    }
}
