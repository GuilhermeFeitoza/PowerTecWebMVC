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
    public class BeneficiosController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: Beneficios
        public ActionResult Index()
        {
            return View(db.tbBeneficio.ToList());
        }

        // GET: Beneficios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbBeneficio tbBeneficio = db.tbBeneficio.Find(id);
            if (tbBeneficio == null)
            {
                return HttpNotFound();
            }
            return View(tbBeneficio);
        }

        // GET: Beneficios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBeneficio,Nome,Empresa_prestadora,Valor")] tbBeneficio tbBeneficio)
        {
            if (ModelState.IsValid)
            {
                db.tbBeneficio.Add(tbBeneficio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbBeneficio);
        }

        // GET: Beneficios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbBeneficio tbBeneficio = db.tbBeneficio.Find(id);
            if (tbBeneficio == null)
            {
                return HttpNotFound();
            }
            return View(tbBeneficio);
        }

        // POST: Beneficios/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBeneficio,Nome,Empresa_prestadora,Valor")] tbBeneficio tbBeneficio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbBeneficio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbBeneficio);
        }

        // GET: Beneficios/
        // /5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbBeneficio tbBeneficio = db.tbBeneficio.Find(id);
            if (tbBeneficio == null)
            {
                return HttpNotFound();
            }
            return View(tbBeneficio);
        }

        // POST: Beneficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbBeneficio tbBeneficio = db.tbBeneficio.Find(id);
            db.tbBeneficio.Remove(tbBeneficio);
            db.SaveChanges();
            return RedirectToAction("Index");
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
