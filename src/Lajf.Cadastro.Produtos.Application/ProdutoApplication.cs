using Lajf.Cadastro.Produtos.Domain.Entities;
using Lajf.Cadastro.Produtos.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lajf.Cadastro.Produtos.Application
{
    public class ProdutoApplication
    {
        private readonly ProdutoRepository _produtoRepository;        

        public ProdutoApplication(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool Inserir(Produto produto)
        {
            _produtoRepository.Inserir(produto);

            return true;
        }

        public bool Alterar(Produto produto)
        {
            _produtoRepository.Alterar(produto);

            return true;
        }

        public bool Deletar(string nome)
        {
            _produtoRepository.Deletar(nome);

            return true;
        }

        public List<Produto> ObterTodos()
        {
            List<Produto> listaProduto = _produtoRepository.ObterTodos();

            return listaProduto;
        }

        public Produto ObterPorNome(string nome)
        {
            Produto produto = _produtoRepository.ObterPorNome(nome);

            return produto;
        }
    }
}
