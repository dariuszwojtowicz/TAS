using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Browar.Controllers
{
    public class AddController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dodawanie";

            return View();
        }
    }
}