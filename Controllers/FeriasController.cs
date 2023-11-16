using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerTecWeb;

namespace PowerTecWeb.Views.AreaGerente
{
    public class FeriasController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: Ferias
        public ActionResult Index()
        {
            var tbFerias = db.tbFerias.Include(t => t.tbFuncionario);
            return View(tbFerias.ToList());
        }

        // GET: Ferias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFerias tbFerias = db.tbFerias.Find(id);
            if (tbFerias == null)
            {
                return HttpNotFound();
            }
            return View(tbFerias);
        }

        // GET: Ferias/Create
        public ActionResult SolicitarFerias()
        {
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo",Session["IdFuncionario"]);
            return View();
        }

        // POST: Ferias/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFerias,Data_Inicio,Data_Fim,Aprovado,IdFuncionario")] tbFerias tbFerias)
        {
            if (ModelState.IsValid)
            {
                db.tbFerias.Add(tbFerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbFerias.IdFuncionario);
            return RedirectToAction("IndexColaborador","AreaColaborador");
        }

        // GET: Ferias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFerias tbFerias = db.tbFerias.Find(id);
            if (tbFerias == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbFerias.IdFuncionario);
            return View(tbFerias);
        }

        // POST: Ferias/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFerias,Data_Inicio,Data_Fim,Aprovado,IdFuncionario")] tbFerias tbFerias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbFerias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbFerias.IdFuncionario);
            return View(tbFerias);
        }

        // GET: Ferias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFerias tbFerias = db.tbFerias.Find(id);
            if (tbFerias == null)
            {
                return HttpNotFound();
            }
            return View(tbFerias);
        }

        // POST: Ferias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbFerias tbFerias = db.tbFerias.Find(id);
            db.tbFerias.Remove(tbFerias);
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
