using CodeBibliotec.Interfaces;
using CodeBibliotec.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBibliotec.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCategoriaPorId(int id)
        {
            try
            {
                var categoria = await _categoriaService.ObterCategoriaPorIdAsync(id);
                if (categoria == null)
                    return NotFound(new { mensagem = "Categoria não encontrada" });

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao obter categoria", erro = ex.Message });
            }
        }




        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            try
            {
                var categorias = await _categoriaService.ObterTodasCategoriasAsync();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao listar categorias", erro = ex.Message });
            }
        }





        [HttpPost("cadastrar")]
        [Authorize(Roles = "Bibliotecaria")]
        public async Task<IActionResult> CadastrarCategoria(CategoriaViewModel categoriaViewModel)
        {
            // Verifica se os dados enviados no modelo são válidos, conforme a validação de CategoriaViewModel
            if (!ModelState.IsValid)
                // Retorna erro 400 (Bad Request) com detalhes da validação
                return BadRequest(ModelState);

            try
            {
                // Chama o serviço para cadastrar a categoria de forma assíncrona
                var categoria = await _categoriaService.CadastrarCategoriaAsync(categoriaViewModel);

                // Retorna status 201 (Created), com a rota para buscar a categoria criada
                return CreatedAtAction(nameof(ObterCategoriaPorId), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna status 500 com mensagem personalizada e detalhe do erro
                return StatusCode(500, new { mensagem = "Erro ao cadastrar categoria", erro = ex.Message });
            }
        }



    }
}
