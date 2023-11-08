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
    public class PontosController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: Pontos
        public ActionResult Index()
        {
            var tbPonto = db.tbPonto.Include(t => t.tbFuncionario);
            return View(tbPonto.ToList());
        }

        // GET: Pontos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPonto tbPonto = db.tbPonto.Find(id);
            if (tbPonto == null)
            {
                return HttpNotFound();
            }
            return View(tbPonto);
        }

        // GET: Pontos/Create
        public ActionResult Create()
        {
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo");
            return View();
        }

        // POST: Pontos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPonto,Data_entrada,Data_saida,Saida_almoco,Hora_extra,Feriado,IdFuncionario")] tbPonto tbPonto)
        {
            if (ModelState.IsValid)
            {
                db.tbPonto.Add(tbPonto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbPonto.IdFuncionario);
            return View(tbPonto);
        }

        // GET: Pontos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPonto tbPonto = db.tbPonto.Find(id);
            if (tbPonto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbPonto.IdFuncionario);
            return View(tbPonto);
        }

        // POST: Pontos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPonto,Data_entrada,Data_saida,Saida_almoco,Hora_extra,Feriado,IdFuncionario")] tbPonto tbPonto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPonto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbPonto.IdFuncionario);
            return View(tbPonto);
        }

        // GET: Pontos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPonto tbPonto = db.tbPonto.Find(id);
            if (tbPonto == null)
            {
                return HttpNotFound();
            }
            return View(tbPonto);
        }

        // POST: Pontos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPonto tbPonto = db.tbPonto.Find(id);
            db.tbPonto.Remove(tbPonto);
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
