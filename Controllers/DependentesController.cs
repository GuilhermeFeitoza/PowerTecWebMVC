using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerTecWeb;

namespace PowerTecWeb.Models
{
    public class DependentesController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: Dependentes
        public ActionResult Index()
        {
            var tbDependente = db.tbDependente.Include(t => t.tbFuncionario);
            return View(tbDependente.ToList());
        }

        // GET: Dependentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDependente tbDependente = db.tbDependente.Find(id);
            if (tbDependente == null)
            {
                return HttpNotFound();
            }
            return View(tbDependente);
        }

        // GET: Dependentes/Create
        public ActionResult Create(int? id)
        {
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo",id);
            return View();
        }

        // POST: Dependentes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDependente,Nome,Data_nascimento,Cpf,IdFuncionario")] tbDependente tbDependente)
        {
            if (ModelState.IsValid)
            {
                db.tbDependente.Add(tbDependente);
                db.SaveChanges();
                return RedirectToAction("Index","Funcionarios");
            }

            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbDependente.IdFuncionario);
            return View(tbDependente);
        }

        // GET: Dependentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDependente tbDependente = db.tbDependente.Find(id);
            if (tbDependente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbDependente.IdFuncionario);
            return View(tbDependente);
        }

        // POST: Dependentes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDependente,Nome,Data_nascimento,Cpf,IdFuncionario")] tbDependente tbDependente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbDependente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbDependente.IdFuncionario);
            return View(tbDependente);
        }

        // GET: Dependentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDependente tbDependente = db.tbDependente.Find(id);
            if (tbDependente == null)
            {
                return HttpNotFound();
            }
            return View(tbDependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbDependente tbDependente = db.tbDependente.Find(id);
            db.tbDependente.Remove(tbDependente);
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
