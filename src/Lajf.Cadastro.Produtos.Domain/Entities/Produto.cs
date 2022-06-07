using Lajf.Cadastro.Produtos.Domain.Entities.Base;
using Lajf.Cadastro.Produtos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lajf.Cadastro.Produtos.Domain.Entities
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public Produto(Guid fornecedorId, string nome, string descricao, decimal valor)
        {
            FornecedorId = fornecedorId;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public Produto(Guid id, Guid fornecedorId, string nome, string descricao, decimal valor, bool ativo)
        {
            Id = id;
            FornecedorId = fornecedorId;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;            
            Ativo = ativo;
        }

    }
}
