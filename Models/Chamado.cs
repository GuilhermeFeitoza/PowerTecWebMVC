using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Chamado
    {
        public int IdChamado { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        [DisplayName("Data do chamado")]
        [DataType(DataType.Date)]
        public System.DateTime Data_chamado { get; set; }
        public Nullable<int> IdFuncionario { get; set; }

        public virtual tbFuncionario tbFuncionario { get; set; }
    }
}