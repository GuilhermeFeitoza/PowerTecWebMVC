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
    
    public partial class tbFerias
    {
        public int IdFerias { get; set; }
        public System.DateTime Data_Inicio { get; set; }
        public System.DateTime Data_Fim { get; set; }
        public string Aprovado { get; set; }
        public Nullable<int> IdFuncionario { get; set; }
    
        public virtual tbFuncionario tbFuncionario { get; set; }
    }
}
