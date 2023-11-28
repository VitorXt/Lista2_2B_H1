using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.Services;
using GestaoDeProdutos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FornecedorController : ControllerBase
    {
        #region - Propriedades e Construtores

        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        #endregion

        #region - CRUD

        #region GET

        [HttpGet("obtertodos")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_fornecedorService.ObterTodos());
            }
            catch
            {
                return BadRequest("Nenhum fornecedor encontrado");
            }
        }


        [HttpGet("obterporid/{id}")]
        public IActionResult GetPorId(Guid id)
        {
            try
            {
                return Ok(_fornecedorService.ObterPorId(id));
            }
            catch
            {
                return BadRequest("Nenhum fornecedor encontrado");
            }
        }


        [HttpGet("obterpornome/{nome}")]
        public IActionResult GetPorNome(string nome)
        {
            try
            {
                return Ok(_fornecedorService.ObterPorNome(nome));
            }
            catch
            {
                return BadRequest("Nenhum fornecedor encontrado");
            }
        }


        [HttpGet("obterporcnpj/{cnpj}")]
        public IActionResult GetPorCnpj(string cnpj)
        {
            try
            {
                return Ok(_fornecedorService.ObterPorCnpj(cnpj));
            }
            catch
            {
                return BadRequest("Nenhum fornecedor encontrado");
            }
        }

        #endregion


        #region POST

        [HttpPost("adicionar")]
        public IActionResult Post([FromBody] NovoFornecedorViewModel novoFornecedorViewModel)
        {
            try
            {
                var adicionadoComSucesso = _fornecedorService.Adicionar(novoFornecedorViewModel);
                return Ok("Fornecedor cadastrado com sucesso");
            }
            catch
            {
                return BadRequest("Houve um erro ao cadastrar o fornecedor");
            }

        }

        #endregion


        #region PUT

        [HttpPut("atualizar/{id}")]
        public IActionResult Put([FromBody] AtualizarFornecedorViewlModel fornecedorAtualizado, Guid id)
        {
            try
            {
                var atualizadoComSucesso = _fornecedorService.Atualizar(id, fornecedorAtualizado);
                return Ok("Fornecedor atualizado com sucesso");
            }
            catch
            {
                return BadRequest("Houve um erro ao atualizar o fornecedor");
            }
        }

        #endregion

        #endregion
    }
}
