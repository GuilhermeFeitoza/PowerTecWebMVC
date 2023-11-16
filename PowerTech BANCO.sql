IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'PowerTec')
  BEGIN
    CREATE DATABASE PowerTec
    END
    GO
USE PowerTec
GO
CREATE TABLE tbDepartamento(
IdDepartamento INT PRIMARY KEY IDENTITY,
Nome VARCHAR(100) NOT NULL,
Descricao VARCHAR(50),
Responsavel VARCHAR(100)NOT NULL,
Data_criacao DATE NOT NULL);
GO
CREATE TABLE tbCargo(
IdCargo INT PRIMARY KEY IDENTITY,
Nome VARCHAR(100) NOT NULL,
Descricao VARCHAR(200)NOT NULL,
Salario_base DECIMAL(10,2) NOT NULL,
Beneficios VARCHAR(100),
Carga_horaria VARCHAR(50),
Data_criacao DATE,
IdDepartamento INT FOREIGN KEY REFERENCES tbDepartamento(IdDepartamento)
);
GO
CREATE TABLE tbEndereco(
IdEndereco INT PRIMARY KEY IDENTITY,
Logradouro VARCHAR(100) NOT NULL,
Numero VARCHAR(10) NOT NULL,
Complemento VARCHAR (100),
Bairro VARCHAR(100) NOT NULL,
Cidade VARCHAR(50) NOT NULL,
Estado VARCHAR(50) NOT NULL,
Cep VARCHAR(10) NOT NULL)
GO
CREATE TABLE tbFuncionario(
IdFuncionario INT PRIMARY KEY IDENTITY,
Nome_completo VARCHAR(100) NOT NULL,
Cpf VARCHAR(14) NOT NULL,
Rg VARCHAR(20) NOT NULL,
Telefone VARCHAR(20) NOT NULL,
Email VARCHAR(100) NOT NULL,
Estado_civil VARCHAR(10) NOT NULL,
Salario decimal(10,2) not null,
Data_admissao date not null,
Jornada_trabalho VARCHAR(50)NOT NULL,
Tipo_contrato VARCHAR(50) NOT NULL,
Banco_agencia VARCHAR(100) NOT NULL,
Usuario VARCHAR(100) NOT NULL,
Senha VARCHAR (30) NOT  NULL,
Numero_conta VARCHAR(20) NOT NULL,
NivelAcesso int,
IdCargo INT FOREIGN KEY REFERENCES tbCargo(IdCargo),
IdEndereco INT FOREIGN KEY REFERENCES tbEndereco(IdEndereco),
)
GO
CREATE TABLE tbPonto(
IdPonto INT PRIMARY KEY IDENTITY,
Data_entrada DATETIME,
Data_saida DATETIME,
Saida_almoco DATETIME ,
Hora_extra CHAR(1)NOT NULL,
Feriado CHAR(1)NOT NULL, --S OU N
IdFuncionario INT FOREIGN KEY REFERENCES tbFuncionario(IdFuncionario),
)
GO
CREATE TABLE tbBeneficio(
IdBeneficio INT PRIMARY KEY IDENTITY,
Nome VARCHAR(50)NOT NULL,
Empresa_prestadora VARCHAR(80)NOT NULL,
Valor decimal (10,2)NOT NULL,
)
GO
CREATE TABLE tbFerias(
IdFerias INT PRIMARY KEY IDENTITY NOT NULL,
Data_Inicio DATE NOT NULL,
Data_Fim DATE NOT NULL,
Aprovado CHAR(1) NOT NULL,-- S OU N
IdFuncionario INT FOREIGN KEY REFERENCES tbFuncionario(IdFuncionario),
)
GO
CREATE TABLE tbChamado(
IdChamado INT PRIMARY KEY IDENTITY,
Assunto VARCHAR(200)NOT NULL,
Mensagem VARCHAR(400)NOT NULL,
Data_chamado DATE NOT NULL,
IdFuncionario INT FOREIGN KEY REFERENCES tbFuncionario(IdFuncionario),
);
GO
CREATE TABLE tbFuncionarioBeneficio(
IdFuncionarioBeneficio INT PRIMARY KEY IDENTITY,
IdFuncionario INT FOREIGN KEY REFERENCES tbFuncionario(IdFuncionario),
IdBeneficio INT FOREIGN KEY REFERENCES tbBeneficio(IdBeneficio),
Aprovado CHAR(1),
);
GO
CREATE TABLE tbDependente(
IdDependente INT PRIMARY KEY IDENTITY,
Nome VARCHAR(100) NOT NULL,
Data_nascimento DATE NOT NULL,
Cpf varchar(14) NOT NULL,
IdFuncionario INT FOREIGN KEY REFERENCES tbFuncionario(IdFuncionario),
)
GO
CREATE TABLE tbHolerite(
IdHolerite INT PRIMARY KEY IDENTITY,
Periodo VARCHAR(50),
Salario_base DECIMAL NOT NULL,
Horas_extras DECIMAL NOT NULL,
Comissoes DECIMAL NOT NULL,
Outros_proventos DECIMAL NOT NULL,
Total_proventos DECIMAL NOT NULL,
Plano_saude DECIMAL NOT NULL,
Vale_transporte DECIMAL,
Total_deducoes DECIMAL,
Valor_liquido DECIMAL NOT NULL,
Ferias DECIMAL NOT NULL,
Aviso_previo decimal,
Beneficios_adicionais DECIMAL NOT NULL,
Outras_Informacoes varchar(1000),
IdFuncionario INT FOREIGN KEY REFERENCES tbFuncionario(IdFuncionario)
)