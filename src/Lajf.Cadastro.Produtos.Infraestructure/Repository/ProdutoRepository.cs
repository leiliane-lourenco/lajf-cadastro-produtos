using Lajf.Cadastro.Produtos.Domain.Entities;
using Lajf.Cadastro.Produtos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Lajf.Cadastro.Produtos.Infraestructure.Repository
{
    public class ProdutoRepository
    {
        private string _connection = @"Data Source =JESSICA-PC\sql2019;Initial Catalog =LajfCadastroProdutosDB; User ID =sa; Password=luana1954";

        public void Inserir(Produto produto)
        {
            int ativo = produto.Ativo ? 1 : 0;

            string query = $"INSERT INTO PRODUTOS " +
                           $"VALUES('{produto.Id}', '{produto.FornecedorId}','{produto.Nome}', '{produto.Descricao}', " +
                           $"       {produto.Valor}, '{produto.DataCadastro.ToString("yyyy-MM-dd")}', {ativo})";

            SqlConnection SqlConnection = new SqlConnection(_connection);

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlConnection.Close();

            //nome, descricao, valor, ativo, fornecedor_id(passar id do fornecedor na tabela Fornecedor)
        }

        public void Alterar(Produto produto)
        {
            int ativo = produto.Ativo ? 1 : 0;

            string query = $"UPDATE PRODUTOS " +
                           $"SET NOME = '{produto.Nome}', " +
                           $"DESCRICAO = '{produto.Descricao}'," +
                           $"VALOR = {produto.Valor}," +
                           $"ATIVO = {ativo} " +
                           $"WHERE ID = '{produto.Id}'";

            SqlConnection SqlConnection = new SqlConnection(_connection);

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlConnection.Close();

            //passar o id do produto: api/produto/id(tabela Produtos)
            //
        }

        public void Deletar(string nome)
        {
            string query = $"DELETE FROM PRODUTOS WHERE NOME = '{nome}' ";

            SqlConnection SqlConnection = new SqlConnection(_connection);

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlConnection.Close();

            //passar o nome do produto: api/produtos/nome
        }

        public List<Produto> ObterTodos()
        {
            string querySql = $"SELECT ID, FORNECEDORID, NOME, DESCRICAO, VALOR, DATACADASTRO, ATIVO FROM PRODUTOS";

            SqlConnection SqlConnection = new SqlConnection(_connection);
            SqlCommand sqlCommand = new SqlCommand(querySql, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlDataReader dadosDoBanco = sqlCommand.ExecuteReader();

            List<Produto> listaProduto = new List<Produto>();
            Produto produto = null;

            while (dadosDoBanco.Read())
            {
                Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
                Guid fornecedorId = Guid.Parse(dadosDoBanco.GetValue(1).ToString());
                string nome = dadosDoBanco.GetValue(2).ToString();
                string descricao = dadosDoBanco.GetValue(3).ToString();
                decimal valor = decimal.Parse(dadosDoBanco.GetValue(4).ToString());
                DateTime dataCadastro = DateTime.Parse(dadosDoBanco.GetValue(5).ToString());
                bool ativo = bool.Parse(dadosDoBanco.GetValue(6).ToString());

                produto = new Produto(fornecedorId, nome, descricao, valor);
                produto.Id = id;
                produto.Ativo = ativo;

                listaProduto.Add(produto);
            }
            SqlConnection.Close();

            return listaProduto;

            //basta usar o GET, não precisa de parametro
        }

        public Produto ObterPorNome(string nome)
        {
            string query = $"SELECT ID, FORNECEDORID, NOME, DESCRICAO, VALOR, DATACADASTRO, ATIVO FROM PRODUTOS WHERE NOME = '{nome}' ";

            SqlConnection SqlConnection = new SqlConnection(_connection);
            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlDataReader dadosDoBanco = sqlCommand.ExecuteReader();

            Produto produto = null;

            while (dadosDoBanco.Read())
            {
                Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
                Guid fornecedorId = Guid.Parse(dadosDoBanco.GetValue(1).ToString());
                string nomeProduto = dadosDoBanco.GetValue(2).ToString();
                string descricao = dadosDoBanco.GetValue(3).ToString();
                decimal valor = decimal.Parse(dadosDoBanco.GetValue(4).ToString());
                DateTime dataCadastro = DateTime.Parse(dadosDoBanco.GetValue(5).ToString());
                bool ativo = bool.Parse(dadosDoBanco.GetValue(6).ToString());

                produto = new Produto(fornecedorId, nomeProduto, descricao, valor);
                produto.Id = id;
                produto.Ativo = ativo;
                produto.FornecedorId = fornecedorId;
            }

            SqlConnection.Close();

            return produto;

            //passar o nome do produto: api/produtos/nome
        }
    }
}

// get, get por nome, post, delete
// falta put