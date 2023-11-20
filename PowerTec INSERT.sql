USE [PowerTec]
GO

/*Departamentos*/
INSERT INTO [dbo].[tbDepartamento]
           ([Nome]
           ,[Descricao]
           ,[Responsavel]
           ,[Data_criacao])
     VALUES
           ('Financeiro',
		   'Responsavel pelos registros financeiros',
		   'Fulano',
		   '20/11/2023'
		   )
GO
INSERT INTO [dbo].[tbDepartamento]
           ([Nome]
           ,[Descricao]
           ,[Responsavel]
           ,[Data_criacao])
     VALUES
           ('Desenvolvimento',
		   'Responsavel pelos desenvolvimento e suporte',
		   'João',
		   '20/11/2023'
		   )


GO
/*CARGOS*/
INSERT INTO [dbo].[tbCargo]
           ([Nome]
           ,[Descricao]
           ,[Salario_base]
           ,[Beneficios]
           ,[Carga_horaria]
           ,[Data_criacao]
           ,[IdDepartamento])
     VALUES
           ('Analista financeiro',
		   'Analista de finanças',
		   3000,
		   'VT VR',
		   30,
		   '20/11/2023',
		   1
		   )
GO
INSERT INTO [dbo].[tbCargo]
           ([Nome]
           ,[Descricao]
           ,[Salario_base]
           ,[Beneficios]
           ,[Carga_horaria]
           ,[Data_criacao]
           ,[IdDepartamento])
     VALUES
           ('Analista de desenvolvimento I',
		   'Analista de  desenvolvimento e manutenção',
		   3000,
		   'VT VR',
		   30,
		   '20/11/2023',
		   1
		   )
GO
INSERT INTO tbFuncionario (Nome_completo, Cpf, Rg, Telefone, Email, Estado_civil, Salario, Data_admissao, Jornada_trabalho, Tipo_contrato, Banco_agencia, Usuario, Senha, Numero_conta, NivelAcesso, IdCargo, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep)
VALUES
('João Silva', '123.456.789-01', '1234567-8', '(11) 98765-4321', 'joao.silva@email.com', 'Solteiro', 5000.00, '2023-01-15', '40 horas semanais', 'CLT', 'Banco X - Ag. 1234', 'joao123', 'senha123', '987654-1', 0, 1, 'Rua A', '123', 'Apto 456', 'Centro', 'Cidade A', 'Estado A', '12345-678');

INSERT INTO tbFuncionario (Nome_completo, Cpf, Rg, Telefone, Email, Estado_civil, Salario, Data_admissao, Jornada_trabalho, Tipo_contrato, Banco_agencia, Usuario, Senha, Numero_conta, NivelAcesso, IdCargo, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep)
VALUES
('Maria Oliveira', '987.654.321-09', '9876543-2', '(22) 98765-1098', 'maria.oliveira@email.com', 'Casada', 6000.00, '2022-12-01', '35 horas semanais', 'PJ', 'Banco Y - Ag. 5678', 'maria567', 'senha456', '876543-2', 0, 1, 'Avenida B', '456', NULL, 'Bairro X', 'Cidade B', 'Estado B', '54321-876');

