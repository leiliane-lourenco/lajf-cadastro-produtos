using Lajf.Cadastro.Produtos.Domain.Entities;
using Lajf.Cadastro.Produtos.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lajf.Cadastro.Produtos.Application
{
    public class FornecedorApplication
    {
        private readonly FornecedorRepository _fornecedorRepository;

        public FornecedorApplication(FornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public bool Inserir(Fornecedor fornecedor)
        {
            _fornecedorRepository.Inserir(fornecedor);

            return true;
        }

        public bool Alterar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Alterar(fornecedor);

            return true;
        }

        public bool Deletar(string documento)
        {
            _fornecedorRepository.Deletar(documento);

            return true;
        }

        public List<Fornecedor> ObterTodos()
        {
            List<Fornecedor> listaFornecedor = _fornecedorRepository.ObterTodos();

            return listaFornecedor;
        }

        public Fornecedor ObterPorDocumento(string documento)
        {
           Fornecedor fornecedor = _fornecedorRepository.ObterPorDocumento(documento);

            return fornecedor;
        }

    }
}
