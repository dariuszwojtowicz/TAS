using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Browar.Controllers
{
    public class ShowPiwoesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Katalog Piw";

            return View();
        }
    }
}