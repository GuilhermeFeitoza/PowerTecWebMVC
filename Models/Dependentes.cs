using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Dependentes
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdDependente { get; set; }
        public string Nome { get; set; }

        [DisplayName("Data de nascimento")]
        public System.DateTime Data_nascimento { get; set; }
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        public Nullable<int> IdFuncionario { get; set; }

    }
}