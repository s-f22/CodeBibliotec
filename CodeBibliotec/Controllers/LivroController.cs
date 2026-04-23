using CodeBibliotec.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBibliotec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }



        [HttpGet]
        public async Task<IActionResult> ListarTodosLivros()
        {
            try
            {
                var livros = await _livroService.ObterTodosLivrosAsync();
                return Ok(livros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao listar livros", erro = ex.Message });
            }

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLivroPorId(int id)
        {
            try
            {
                var livro = await _livroService.ObterLivroPorIdAsync(id);
                if (livro == null)
                    return NotFound(new { mensagem = "Livro não encontrado" });

                return Ok(livro);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao obter o livro", erro = ex.Message });
            }
        }

    }
}
