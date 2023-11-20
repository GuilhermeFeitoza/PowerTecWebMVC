using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PowerTecWeb.Models
{
    public class Funcionario
    {
        [DisplayName("Funcionário")]
        public int IdFuncionario { get; set; }
        [DisplayName("Nome completo")]
        public string Nome_completo { get; set; }

        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [DisplayName("RG")]
        public string Rg { get; set; }
        public string Telefone { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Estado civil")]
        public string Estado_civil { get; set; }
        public decimal Salario { get; set; }

        [DisplayName("Data de Admissão")]
        public System.DateTime Data_admissao { get; set; }
        [DisplayName("Jornada de trabalho mensal")]
        public string Jornada_trabalho { get; set; }
        [DisplayName("Tipo de contrato")]
        public string Tipo_contrato { get; set; }

        [DisplayName("Agência")]
        public string Banco_agencia { get; set; }
        [DisplayName("Nº da conta")]
        public string Numero_conta { get; set; }
        [DisplayName("Nível de acesso")]
        public Nullable<int> NivelAcesso { get; set; }
        [DisplayName("Cargo")]
        public Nullable<int> IdCargo { get; set; }
        

        [DisplayName("Usuário")]
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public virtual tbCargo tbCargo { get; set; }

        public virtual ICollection<tbChamado> tbChamado { get; set; }
        public virtual ICollection<tbDependente> tbDependente { get; set; }
        public virtual ICollection<tbFerias> tbFerias { get; set; }
        public virtual ICollection<tbFuncionarioBeneficio> tbFuncionarioBeneficio { get; set; }
        public virtual ICollection<tbHolerite> tbHolerite { get; set; }
        public virtual ICollection<tbPonto> tbPonto { get; set; }
    }
}