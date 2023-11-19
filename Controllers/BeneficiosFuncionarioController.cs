using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerTecWeb;

namespace PowerTecWeb.Controllers
{
    public class BeneficiosFuncionarioController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: BeneficiosFuncionario
        public ActionResult Index(int? id)
        {
            var tbFuncionarioBeneficio = db.tbFuncionarioBeneficio.Include(t => t.tbBeneficio).Include(t => t.tbFuncionario);
            return View(tbFuncionarioBeneficio.Where(d=>d.IdFuncionario == id).ToList());
        }

        // GET: BeneficiosFuncionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionarioBeneficio tbFuncionarioBeneficio = db.tbFuncionarioBeneficio.Find(id);
            if (tbFuncionarioBeneficio == null)
            {
                return HttpNotFound();
            }
            return View(tbFuncionarioBeneficio);
        }

        // GET: BeneficiosFuncionario/Create
        public ActionResult Create()
        {
            ViewBag.IdBeneficio = new SelectList(db.tbBeneficio, "IdBeneficio", "Nome");
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo");
            return View();
        }

        // POST: BeneficiosFuncionario/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFuncionarioBeneficio,IdFuncionario,IdBeneficio")] tbFuncionarioBeneficio tbFuncionarioBeneficio)
        {
            tbFuncionarioBeneficio.Aprovado = "N";
            if (ModelState.IsValid)
            {
                db.tbFuncionarioBeneficio.Add(tbFuncionarioBeneficio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBeneficio = new SelectList(db.tbBeneficio, "IdBeneficio", "Nome", tbFuncionarioBeneficio.IdBeneficio);
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbFuncionarioBeneficio.IdFuncionario);
            return View(tbFuncionarioBeneficio);
        }

        // GET: BeneficiosFuncionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionarioBeneficio tbFuncionarioBeneficio = db.tbFuncionarioBeneficio.Find(id);
            if (tbFuncionarioBeneficio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBeneficio = new SelectList(db.tbBeneficio, "IdBeneficio", "Nome", tbFuncionarioBeneficio.IdBeneficio);
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbFuncionarioBeneficio.IdFuncionario);
            return View(tbFuncionarioBeneficio);
        }

        // POST: BeneficiosFuncionario/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFuncionarioBeneficio,IdFuncionario,IdBeneficio,Aprovado")] tbFuncionarioBeneficio tbFuncionarioBeneficio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbFuncionarioBeneficio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexColaborador","AreaColaborador");
            }
            ViewBag.IdBeneficio = new SelectList(db.tbBeneficio, "IdBeneficio", "Nome", tbFuncionarioBeneficio.IdBeneficio);
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbFuncionarioBeneficio.IdFuncionario);
            return View(tbFuncionarioBeneficio);
        }

        // GET: BeneficiosFuncionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionarioBeneficio tbFuncionarioBeneficio = db.tbFuncionarioBeneficio.Find(id);
            if (tbFuncionarioBeneficio == null)
            {
                return HttpNotFound();
            }
            return View(tbFuncionarioBeneficio);
        }

        // POST: BeneficiosFuncionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbFuncionarioBeneficio tbFuncionarioBeneficio = db.tbFuncionarioBeneficio.Find(id);
            db.tbFuncionarioBeneficio.Remove(tbFuncionarioBeneficio);
            db.SaveChanges();
            return RedirectToAction("IndexColaborador","AreaColaborador");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
