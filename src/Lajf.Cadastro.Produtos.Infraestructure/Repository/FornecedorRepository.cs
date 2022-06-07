using Lajf.Cadastro.Produtos.Domain.Entities;
using Lajf.Cadastro.Produtos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Lajf.Cadastro.Produtos.Infraestructure.Repository
{
    public class FornecedorRepository
    {
        private string _connection = @"Data Source =JESSICA-PC\sql2019;Initial Catalog =LajfCadastroProdutosDB; User ID =sa; Password=luana1954";

        public void Inserir(Fornecedor fornecedor)
        {
            int ativo = fornecedor.Ativo ? 1 : 0;

            string query = $"INSERT INTO FORNECEDORES " +
                           $"VALUES('{fornecedor.Id}','{fornecedor.Nome}', '{fornecedor.Documento}', " +
                           $"       {fornecedor.TipoFornecedor.GetHashCode()}, {ativo})";

            SqlConnection SqlConnection = new SqlConnection(_connection);

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public void Alterar(Fornecedor fornecedor)
        {
            int ativo = fornecedor.Ativo ? 1 : 0;

            string query = $"UPDATE FORNECEDORES " +
                           $"SET NOME = '{fornecedor.Nome}'," +
                           $"TIPOFORNECEDOR = {fornecedor.TipoFornecedor.GetHashCode()}, " +
                           $"ATIVO = {ativo} " +
                           $"WHERE DOCUMENTO = '{fornecedor.Documento}'";

            SqlConnection SqlConnection = new SqlConnection(_connection);

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public void Deletar(string documento)
        {
            string query = $"DELETE FROM FORNECEDORES WHERE DOCUMENTO = '{documento}' ";

            SqlConnection SqlConnection = new SqlConnection(_connection);

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public List<Fornecedor> ObterTodos()
        {
            string querySql = $"SELECT ID, NOME, DOCUMENTO, TIPOFORNECEDOR, ATIVO FROM FORNECEDORES";

            SqlConnection SqlConnection = new SqlConnection(_connection);
            SqlCommand sqlCommand = new SqlCommand(querySql, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlDataReader dadosDoBanco = sqlCommand.ExecuteReader();

            List<Fornecedor> listaFornecedor = new List<Fornecedor>();
            Fornecedor fornecedor = null;

            while (dadosDoBanco.Read())
            {
                Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
                string nome = dadosDoBanco.GetValue(1).ToString();
                string documentoFornecedor = dadosDoBanco.GetValue(2).ToString();
                int tipoFornecedor = int.Parse(dadosDoBanco.GetValue(3).ToString());
                bool ativo = bool.Parse(dadosDoBanco.GetValue(4).ToString());

                fornecedor = new Fornecedor(nome, documentoFornecedor, (TipoFornecedor)tipoFornecedor);
                fornecedor.Id = id;
                fornecedor.Ativo = ativo;

                listaFornecedor.Add(fornecedor);
            }
            SqlConnection.Close();

            return listaFornecedor;
        }


        public Fornecedor ObterPorDocumento(string documento)
        {
            string query = $"SELECT ID, NOME, DOCUMENTO, TIPOFORNECEDOR, ATIVO FROM FORNECEDORES WHERE DOCUMENTO = '{documento}' ";

            SqlConnection SqlConnection = new SqlConnection(_connection);
            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlDataReader dadosDoBanco = sqlCommand.ExecuteReader();

            Fornecedor fornecedor = null;

            while (dadosDoBanco.Read())
            {
                Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
                string nome = dadosDoBanco.GetValue(1).ToString();
                string documentoFornecedor = dadosDoBanco.GetValue(2).ToString();
                int tipoFornecedor = int.Parse(dadosDoBanco.GetValue(3).ToString());
                bool ativo = bool.Parse(dadosDoBanco.GetValue(4).ToString());

                fornecedor = new Fornecedor(nome, documentoFornecedor, (TipoFornecedor)tipoFornecedor);
                fornecedor.Id = id;
                fornecedor.Ativo = ativo;
            }

            SqlConnection.Close();

            return fornecedor;
        }
    }
}

//obter todos, deletar
//inserir, alterar, deletar, buscar todos e buscar por doc
//validar todos

//começar do domain - classe
//depois repository
//application
