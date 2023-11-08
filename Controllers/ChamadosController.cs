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
    public class ChamadosController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: tbChamados
        public ActionResult Index()
        {
            var tbChamado = db.tbChamado.Include(t => t.tbFuncionario);
            return View(tbChamado.ToList());
        }

        // GET: tbChamados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbChamado tbChamado = db.tbChamado.Find(id);
            if (tbChamado == null)
            {
                return HttpNotFound();
            }
            return View(tbChamado);
        }

        // GET: tbChamados/Create
        public ActionResult Create()
        {
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo");
            return View();
        }

        // POST: tbChamados/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChamado,Assunto,Mensagem,Data_chamado,IdFuncionario")] tbChamado tbChamado)
        {
            if (ModelState.IsValid)
            {
                db.tbChamado.Add(tbChamado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbChamado.IdFuncionario);
            return View(tbChamado);
        }

        // GET: tbChamados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbChamado tbChamado = db.tbChamado.Find(id);
            if (tbChamado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbChamado.IdFuncionario);
            return View(tbChamado);
        }

        // POST: tbChamados/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChamado,Assunto,Mensagem,Data_chamado,IdFuncionario")] tbChamado tbChamado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbChamado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbChamado.IdFuncionario);
            return View(tbChamado);
        }

        // GET: tbChamados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbChamado tbChamado = db.tbChamado.Find(id);
            if (tbChamado == null)
            {
                return HttpNotFound();
            }
            return View(tbChamado);
        }

        // POST: tbChamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbChamado tbChamado = db.tbChamado.Find(id);
            db.tbChamado.Remove(tbChamado);
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
