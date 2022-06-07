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
    
    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorApplication _fornecedorApplication;

        public FornecedorController()
        {
            FornecedorRepository fornecedorRepository = new FornecedorRepository();

            _fornecedorApplication = new FornecedorApplication(fornecedorRepository);
            //passa aqui para ir application
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] FornecedorViewModel fornecedorViewModel)
        {
            Fornecedor fornecedor =
                new Fornecedor(fornecedorViewModel.Nome, fornecedorViewModel.Documento, (TipoFornecedor)fornecedorViewModel.TipoFornecedor);

            bool resultado = _fornecedorApplication.Inserir(fornecedor);

            if (resultado)
                return Ok(fornecedor);

            else
                return BadRequest();
        }
        [HttpPut("{documento}")]
        public IActionResult Alterar(string documento, [FromBody] Fornecedor fornecedorViewModel)
        {
            bool resultado = _fornecedorApplication.Alterar(fornecedorViewModel);

            if (resultado)
                return Ok(fornecedorViewModel);

            else
                return BadRequest();
        }

        [HttpDelete ("{documento}")]
        public IActionResult Deletar(string documento)
        {
            bool resultado = _fornecedorApplication.Deletar(documento);

            if (resultado)
                return NoContent();

            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {

            List<Fornecedor> listaFornecedor = _fornecedorApplication.ObterTodos();

            if (listaFornecedor == null)
                return NotFound();

            return Ok(listaFornecedor);
        }

        [HttpGet("{documento}")]
        public IActionResult ObterPorDocumento(string documento)
        {

            Fornecedor fornecedor = _fornecedorApplication.ObterPorDocumento(documento);

            if (fornecedor == null)  
                return NotFound();

            return Ok(fornecedor);
        }

    }
}
