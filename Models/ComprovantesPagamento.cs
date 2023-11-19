using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class ComprovantesPagamento
    {

   
        public int IdHolerite { get; set; }

        [DisplayName("Data inicial")]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data final")]
        public DateTime DataFinal { get; set; }
        [DisplayName("Salário base")]
        public decimal Salario_base { get; set; }
        [DisplayName("Horas extras")]
        public decimal Horas_extras { get; set; }
        [DisplayName("Comissões")]
        public decimal Comissoes { get; set; }
        [DisplayName("Outros proventos")]
        public decimal Outros_proventos { get; set; }

        [DisplayName("Total proventos")]
        public decimal Total_proventos { get; set; }
        [DisplayName("Plano de saúde")]
        public decimal Plano_saude { get; set; }
        [DisplayName("Vale transporte")]
        public Nullable<decimal> Vale_transporte { get; set; }

        [DisplayName("Total de deduções")]
        public Nullable<decimal> Total_deducoes { get; set; }
        [DisplayName("Valor liquido")]
        public decimal Valor_liquido { get; set; }
        public decimal Ferias { get; set; }

        [DisplayName("Aviso previo")]
        public Nullable<decimal> Aviso_previo { get; set; }
        [DisplayName("Beneficios adicionais")]
        public decimal Beneficios_adicionais { get; set; }

        [DisplayName("Outras informações")]
        public string Outras_Informacoes { get; set; }
        public Nullable<int> IdFuncionario { get; set; }

        public virtual tbFuncionario tbFuncionario { get; set; }
    }
}