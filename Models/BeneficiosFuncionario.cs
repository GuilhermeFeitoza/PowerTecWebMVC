using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class BeneficiosFuncionario
    {
        
        public int IdFuncionarioBeneficio { get; set; }
        [DisplayName("Funcionario Solicitante")]
        public Nullable<int> IdFuncionario { get; set; }
        [DisplayName("Beneficio")]
        public Nullable<int> IdBeneficio { get; set; }
        public string Aprovado { get; set; }

        public virtual tbBeneficio tbBeneficio { get; set; }
        public virtual tbFuncionario tbFuncionario { get; set; }
    }
}