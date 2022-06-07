--CREATE TABLE [dbo].[Fornecedores](
--[Id] [uniqueidentifier] NOT NULL,
--[Nome] [varchar](200) NOT NULL,
--[Documento] [varchar](14) NOT NULL,
--[TipoFornecedor] [int] NOT NULL,
--[Ativo] [bit] NOT NULL,
--CONSTRAINT [PK_Fornecedores] PRIMARY KEY CLUSTERED
--(
--[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
----------------------------------------------------------------

--CREATE TABLE [dbo].[Enderecos](
--[Id] [uniqueidentifier] NOT NULL,
--[FornecedorId] [uniqueidentifier] NOT NULL,
--[Logradouro] [varchar](200) NOT NULL,
--[Numero] [varchar](50) NOT NULL,
--[Complemento] [varchar](250) NULL,
--[Cep] [varchar](8) NOT NULL,
--[Bairro] [varchar](100) NOT NULL,
--[Cidade] [varchar](100) NOT NULL,
--[Estado] [varchar](50) NOT NULL,
--CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED
--(
--[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO


--ALTER TABLE [dbo].[Enderecos] WITH CHECK ADD CONSTRAINT [FK_Enderecos_Fornecedores_FornecedorId] FOREIGN KEY([FornecedorId])
--REFERENCES [dbo].[Fornecedores] ([Id])
--GO


--ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Fornecedores_FornecedorId]
--GO

-----------------------------------------------------------------------

--CREATE TABLE [dbo].[Produtos](
--[Id] [uniqueidentifier] NOT NULL,
--[FornecedorId] [uniqueidentifier] NOT NULL,
--[Nome] [varchar](200) NOT NULL,
--[Descricao] [varchar](1000) NOT NULL,
--[Valor] [decimal](18, 2) NOT NULL,
--[DataCadastro] [datetime2](7) NOT NULL,
--[Ativo] [bit] NOT NULL,
--CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED
--(
--[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO


--ALTER TABLE [dbo].[Produtos] WITH CHECK ADD CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId] FOREIGN KEY([FornecedorId])
--REFERENCES [dbo].[Fornecedores] ([Id])
--GO


--ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId]
--GO

-----------------------------------------------------------------------

SELECT * FROM PRODUTOS
SELECT * FROM FORNECEDORES --get post push delete (pega, inclui, altera e apaga)
SELECT * FROM ENDERECOS

--documento 14 digitos
--primeiro cadastra o fornecedor, pq nao posso ter endereço sem fornecedor
--e o endereco

INSERT INTO FORNECEDORES VALUES(NEWID(),'TESTE', '12345678901234',1, 1)