//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PowerTecWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class tbPonto
    {
        public int IdPonto { get; set; }
        public Nullable<System.DateTime> Data_entrada { get; set; }
        public Nullable<System.DateTime> Data_saida { get; set; }
        public Nullable<System.DateTime> Saida_almoco { get; set; }
        public string Hora_extra { get; set; }
        public string Feriado { get; set; }
        [DisplayName("Funcionario")]
        public Nullable<int> IdFuncionario { get; set; }
    
        public virtual tbFuncionario tbFuncionario { get; set; }
    }
}
