using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Cargo
    {

        public int IdCargo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [DisplayName("Salário base")]
        public decimal Salario_base { get; set; }
        public string Beneficios { get; set; }
        [DisplayName("Carga horária")]
        public string Carga_horaria { get; set; }
        [DisplayName("Data da criação")]
        public Nullable<System.DateTime> Data_criacao { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public virtual tbDepartamento tbDepartamento { get; set; }
        public virtual ICollection<tbFuncionario> tbFuncionario { get; set; }
    }
}