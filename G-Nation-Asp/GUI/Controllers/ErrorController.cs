using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            ViewBag.StatusCode = statusCode + " Error";
            return View();
        }
    }
    }
