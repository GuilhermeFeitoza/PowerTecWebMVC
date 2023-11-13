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
    public class FuncionariosController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var tbFuncionario = db.tbFuncionario.Include(t => t.tbCargo).Include(t => t.tbEndereco);
            return View(tbFuncionario.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionario tbFuncionario = db.tbFuncionario.Find(id);
            if (tbFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tbFuncionario);
        }
        public ActionResult MeuCadastro(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionario tbFuncionario = db.tbFuncionario.Find(id);
            if (tbFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tbFuncionario);
        }

        public ActionResult MeusComprovantes(int? id) {

            var tbHolerite = db.tbHolerite.Include(t => t.tbFuncionario);
            return View(tbHolerite.Where(d=>d.IdFuncionario == id).ToList());




        }
       
        public ActionResult MeusChamados(int?id)
        {
            var tbChamado = db.tbChamado.Include(t => t.tbFuncionario);
            tbChamado = tbChamado.Where(d => d.IdFuncionario == id);
            return View(tbChamado.ToList());
        }

        public ActionResult MinhasFerias(int? id)
        {
            var tbFerias = db.tbFerias.Include(t => t.tbFuncionario);
            tbFerias = tbFerias.Where(d => d.IdFuncionario == id);
            return View(tbFerias.ToList());
        }

        public ActionResult Logout() {
            Session.RemoveAll();
            return RedirectToAction("Index","Home");
        
        }
        public ActionResult MeuPonto(int? id)
        {
            var tbPonto = db.tbPonto.Include(t => t.tbFuncionario);
            tbPonto = tbPonto.Where(d => d.IdFuncionario == id);
            return View(tbPonto.ToList());
        }


        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.tbCargo, "IdCargo", "Nome");
            ViewBag.IdEndereco = new SelectList(db.tbEndereco, "IdEndereco", "Logradouro");
            return View();
        }

        // POST: Funcionarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFuncionario,Nome_completo,Cpf,Rg,Telefone,Email,Estado_civil,Salario,Data_admissao,Jornada_trabalho,Tipo_contrato,Banco_agencia,Numero_conta,NivelAcesso,Usuario,Senha,IdCargo,IdEndereco")] tbFuncionario tbFuncionario)
        {
            if (ModelState.IsValid)
            {
                db.tbFuncionario.Add(tbFuncionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.tbCargo, "IdCargo", "Nome", tbFuncionario.IdCargo);
            ViewBag.IdEndereco = new SelectList(db.tbEndereco, "IdEndereco", "Logradouro", tbFuncionario.IdEndereco);
            return View(tbFuncionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionario tbFuncionario = db.tbFuncionario.Find(id);
            if (tbFuncionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.tbCargo, "IdCargo", "Nome", tbFuncionario.IdCargo);
            ViewBag.IdEndereco = new SelectList(db.tbEndereco, "IdEndereco", "Logradouro", tbFuncionario.IdEndereco);
            return View(tbFuncionario);
        }

        // POST: Funcionarios/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFuncionario,Nome_completo,Cpf,Rg,Telefone,Email,Estado_civil,Salario,Data_admissao,Jornada_trabalho,Tipo_contrato,Banco_agencia,Numero_conta,NivelAcesso,IdCargo,IdEndereco")] tbFuncionario tbFuncionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbFuncionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.tbCargo, "IdCargo", "Nome", tbFuncionario.IdCargo);
            ViewBag.IdEndereco = new SelectList(db.tbEndereco, "IdEndereco", "Logradouro", tbFuncionario.IdEndereco);
            return View(tbFuncionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFuncionario tbFuncionario = db.tbFuncionario.Find(id);
            if (tbFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tbFuncionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbFuncionario tbFuncionario = db.tbFuncionario.Find(id);
            db.tbFuncionario.Remove(tbFuncionario);
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
