using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Departamento
    {

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        [DisplayName("Data da criação")]
        public System.DateTime Data_criacao { get; set; }

        public virtual ICollection<tbCargo> tbCargo { get; set; }
    }


}