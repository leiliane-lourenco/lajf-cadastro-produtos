using Lajf.Cadastro.Produtos.Domain.Entities.Base;
using Lajf.Cadastro.Produtos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lajf.Cadastro.Produtos.Domain.Entities
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor(string nome, string documento, TipoFornecedor tipoFornecedor)
        {
            Nome = nome;
            Documento = documento;
            TipoFornecedor = tipoFornecedor;
            Ativo = true;
        }
       
    }
}
