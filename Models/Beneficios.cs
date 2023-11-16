using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Beneficios
    {


        public int IdBeneficio { get; set; }

        [DisplayName("Nome do Beneficio")]
        public string Nome { get; set; }

        [DisplayName("Empresa prestadora")]
        public string Empresa_prestadora { get; set; }
        public decimal Valor { get; set; }
    }
}