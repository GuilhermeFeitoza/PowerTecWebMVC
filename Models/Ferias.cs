using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Ferias
    {
        public int IdFerias { get; set; }
        [DisplayName("Data de inicio")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Data_Inicio { get; set; }
        [DisplayName("Data de término")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Data_Fim { get; set; }
        public string Aprovado { get; set; }
        [DisplayName("Funcionário")]
        public Nullable<int> IdFuncionario { get; set; }

    }
}