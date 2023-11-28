using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.Services;
using GestaoDeProdutos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Post(NovaCategoriaViewModel categoriaViewModel)
        {
            await _categoriaService.Adicionar(categoriaViewModel);

            return Ok();
        }

        [HttpGet]
        [Route("ObterTodas")]
        public IActionResult Get()
        {
            return Ok(_categoriaService.ObterTodas());
        }
    }
}
