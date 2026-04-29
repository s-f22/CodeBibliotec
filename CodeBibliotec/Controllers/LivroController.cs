using CodeBibliotec.Interfaces;
using CodeBibliotec.ViewModels;
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


        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarLivro(LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var livro = await _livroService.CadastrarLivroAsync(livroViewModel);

                return CreatedAtAction(nameof(ObterLivroPorId), new { id = livro.Id }, livro);

            }
            catch(ArgumentException ex)
            {
                return BadRequest(new {mensagem = ex.Message});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao cadastrar o livro", erro = ex.Message });
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro(int id, LivroViewModel livroViewModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = await _livroService.AtualizarLivroAsync(id, livroViewModel);

                if(!resultado)
                    return NotFound(new {mensagem = "Livro não encontrado"});

                return Ok(new {mensagem = "Livro atualizado com sucesso"});
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new {mensagem = ex.Message});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar livro", erro = ex.Message });
            }

        }






    }
}
