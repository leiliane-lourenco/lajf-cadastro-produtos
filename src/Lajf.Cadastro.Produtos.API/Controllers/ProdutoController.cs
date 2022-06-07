using Lajf.Cadastro.Produtos.API.ViewModel;
using Lajf.Cadastro.Produtos.Application;
using Lajf.Cadastro.Produtos.Domain.Entities;
using Lajf.Cadastro.Produtos.Domain.Enum;
using Lajf.Cadastro.Produtos.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lajf.Cadastro.Produtos.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoApplication _produtoApplication;

        public ProdutoController()
        {
            ProdutoRepository produtoRepository = new ProdutoRepository();

            _produtoApplication = new ProdutoApplication(produtoRepository);
            //passa aqui para ir application
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ProdutoViewModel produtoViewModel)
        {
            Produto produto =
                new Produto(produtoViewModel.FornecedorId, produtoViewModel.Nome, produtoViewModel.Descricao,
                            produtoViewModel.Valor);

            bool resultado = _produtoApplication.Inserir(produto);

            if (resultado)
                return Ok(produto);

            else
                return BadRequest();
        }
        [HttpPut("{Id}")]
        public IActionResult Alterar(Guid id, [FromBody] ProdutoViewModel produtoViewModel)
        {
            Produto produto =
                new Produto(id, produtoViewModel.FornecedorId, produtoViewModel.Nome, produtoViewModel.Descricao,
                    produtoViewModel.Valor, produtoViewModel.Ativo);

            bool resultado = _produtoApplication.Alterar(produto);

            if (resultado)
                return Ok(produto);

            else
                return BadRequest();
        }

        [HttpDelete("{nome}")]
        public IActionResult Deletar(string nome)
        {
            bool resultado = _produtoApplication.Deletar(nome);

            if (resultado)
                return NoContent();

            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {

            List<Produto> listaProduto = _produtoApplication.ObterTodos();

            if (listaProduto == null)
                return NotFound();

            return Ok(listaProduto);
        }

        [HttpGet("{nome}")]
        public IActionResult ObterPorNome(string nome)
        {

            Produto produto = _produtoApplication.ObterPorNome(nome);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }
    }
}
