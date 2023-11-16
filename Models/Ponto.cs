using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using PowerTecWeb;

namespace PowerTecWeb.Models
{

   
    public class Ponto
    {
        public int IdPonto { get; set; }

        [DisplayName("Hora de entrada")]
        [Required]
        public Nullable<System.DateTime> Data_entrada { get; set; }
        [DisplayName("Hora de saída")]
        [Required]
        public Nullable<System.DateTime> Data_saida { get; set; }
        [DisplayName("Saída do almoço")]
        public Nullable<System.DateTime> Saida_almoco { get; set; }
        [DisplayName("Hora extra?")]
        public string Hora_extra { get; set; }

        [DisplayName("Feriado?")]
        public string Feriado { get; set; }

        [DisplayName("Funcionário")]
        public Nullable<int> IdFuncionario { get; set; }

        public virtual tbFuncionario tbFuncionario { get; set; }
    }
}