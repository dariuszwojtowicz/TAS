using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Browar.Controllers
{
    public class ShowBrowarniasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Katalog Browarów";

            return View();
        }
    }
}