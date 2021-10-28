using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dashboard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToRoute("Login");
            }
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return Content("Dashboard");
        }

        public ActionResult Profil()
        {
            return Content("Profil");
        }

        public ActionResult Keluar()
        {
            Session["username"] = null;
            return RedirectToRoute("Login");
        }
    }
}