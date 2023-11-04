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
    public class CargosController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: Cargos
        public ActionResult Index()
        {
            var tbCargo = db.tbCargo.Include(t => t.tbDepartamento);
            return View(tbCargo.ToList());
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargo tbCargo = db.tbCargo.Find(id);
            if (tbCargo == null)
            {
                return HttpNotFound();
            }
            return View(tbCargo);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.tbDepartamento, "IdDepartamento", "Nome");
            return View();
        }

        // POST: Cargos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCargo,Nome,Descricao,Salario_base,Beneficios,Carga_horaria,Data_criacao,IdDepartamento")] tbCargo tbCargo)
        {
            if (ModelState.IsValid)
            {
                db.tbCargo.Add(tbCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.tbDepartamento, "IdDepartamento", "Nome", tbCargo.IdDepartamento);
            return View(tbCargo);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargo tbCargo = db.tbCargo.Find(id);
            if (tbCargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamento = new SelectList(db.tbDepartamento, "IdDepartamento", "Nome", tbCargo.IdDepartamento);
            return View(tbCargo);
        }

        // POST: Cargos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCargo,Nome,Descricao,Salario_base,Beneficios,Carga_horaria,Data_criacao,IdDepartamento")] tbCargo tbCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.tbDepartamento, "IdDepartamento", "Nome", tbCargo.IdDepartamento);
            return View(tbCargo);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargo tbCargo = db.tbCargo.Find(id);
            if (tbCargo == null)
            {
                return HttpNotFound();
            }
            return View(tbCargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCargo tbCargo = db.tbCargo.Find(id);
            db.tbCargo.Remove(tbCargo);
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
