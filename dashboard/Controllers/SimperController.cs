using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dashboard.Controllers
{
    public class SimperController : Controller
    {
        // GET: Simper
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidasiMcu()
        {
            return View();
        }
    }
}