﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PowerTecWeb.Controllers
{
    public class AreaColaboradorController : Controller
    {
        private PowerTecEntities db = new PowerTecEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexColaborador()
        {

            

            return View();
        }

        public ActionResult VerificarLogin(tbFuncionario log)
        {
            if (ModelState.IsValid)
            {
                using (PowerTecEntities db = new PowerTecEntities())
                {
                    var v = db.tbFuncionario.Where(a => a.Usuario.Equals(log.Usuario) && log.Senha.Equals(log.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["IdFuncionario"] = Convert.ToInt32(v.IdFuncionario);
                        Session["Nome"] = Convert.ToString(v.Nome_completo);
                        Session["Cargo"] = db.tbCargo.Where(a => a.IdCargo == v.IdCargo).FirstOrDefault().Nome;
                        Session["Email"] = v.Email.ToString();
                        Session["Telefone"] = v.Telefone.ToString();
                        Session["Desde"] = v.Data_admissao.ToString("dd/MM/yyyy");

                        if ( v.NivelAcesso == 0)
                        {
                            return RedirectToAction("IndexColaborador", "AreaColaborador");
                        }
                        else if (v.NivelAcesso == 1)
                        {
                            return RedirectToAction("IndexGerente", "AreaGerente");

                        }
                      
                        
                    }
                    else
                    {
                        ViewData["LoginApresenta"] = "Login e/ou senha invalido";
                        return RedirectToAction("LoginColaborador", "Home");
                    }
                }
            }

            return View(log);
        }
        public ActionResult NovoCargo()
        {

            return View();
        }
    }
}
