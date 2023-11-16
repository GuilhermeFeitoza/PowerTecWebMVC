using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerTecWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pessoas()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult QuemSomos()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LoginColaborador()
        {
            if (Session["IdFuncionario"] != null)
            {
                return RedirectToAction("IndexColaborador", "AreaColaborador");
            }
            else
            {
                return View();
            }

        }



        public ActionResult Contato()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IndexColaborador()
        {
            return View();
        }



    }
}