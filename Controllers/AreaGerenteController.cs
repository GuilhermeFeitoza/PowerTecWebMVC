using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerTecWeb.Controllers
{
    public class AreaGerenteController : Controller
    {
        public ActionResult IndexGerente()
        {
            return View();
        }
        public ActionResult NovoCargo()
        {
            PowerTecEntities db = new PowerTecEntities();
            var data = db.tbDepartamento.Take(10);
            data.AsEnumerable();
            ViewBag.IdDepartamento = new SelectList(data,"IdDepartamento","Nome");
            return View();
        }
        public ActionResult NovoDepartamento()
        {
            return View();
        }
        public ActionResult NovoFuncionario()
        {
            return View();
        }
    }
}