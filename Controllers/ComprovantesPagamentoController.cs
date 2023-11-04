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
    public class ComprovantesPagamentoController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: ComprovantesPagamento
        public ActionResult Index()
        {
            var tbHolerite = db.tbHolerite.Include(t => t.tbFuncionario);
            return View(tbHolerite.ToList());
        }

        // GET: ComprovantesPagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbHolerite tbHolerite = db.tbHolerite.Find(id);
            if (tbHolerite == null)
            {
                return HttpNotFound();
            }
            return View(tbHolerite);
        }

        // GET: ComprovantesPagamento/Create
        public ActionResult Create()
        {
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo");
            return View();
        }

        // POST: ComprovantesPagamento/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHolerite,Periodo,Salario_base,Horas_extras,Comissoes,Outros_proventos,Total_proventos,Plano_saude,Vale_transporte,Total_deducoes,Valor_liquido,Ferias,Aviso_previo,Beneficios_adicionais,Outras_Informacoes,IdFuncionario")] tbHolerite tbHolerite)
        {
            if (ModelState.IsValid)
            {
                db.tbHolerite.Add(tbHolerite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbHolerite.IdFuncionario);
            return View(tbHolerite);
        }

        // GET: ComprovantesPagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbHolerite tbHolerite = db.tbHolerite.Find(id);
            if (tbHolerite == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbHolerite.IdFuncionario);
            return View(tbHolerite);
        }

        // POST: ComprovantesPagamento/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHolerite,Periodo,Salario_base,Horas_extras,Comissoes,Outros_proventos,Total_proventos,Plano_saude,Vale_transporte,Total_deducoes,Valor_liquido,Ferias,Aviso_previo,Beneficios_adicionais,Outras_Informacoes,IdFuncionario")] tbHolerite tbHolerite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbHolerite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.tbFuncionario, "IdFuncionario", "Nome_completo", tbHolerite.IdFuncionario);
            return View(tbHolerite);
        }

        // GET: ComprovantesPagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbHolerite tbHolerite = db.tbHolerite.Find(id);
            if (tbHolerite == null)
            {
                return HttpNotFound();
            }
            return View(tbHolerite);
        }

        // POST: ComprovantesPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbHolerite tbHolerite = db.tbHolerite.Find(id);
            db.tbHolerite.Remove(tbHolerite);
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
