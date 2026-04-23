using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Services
{
    public class LivroService : ILivroService
    {

        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }




        public Task<bool> AtualizarLivroAsync(int id, LivroViewModel livroViewModel)
        {
            throw new NotImplementedException();
        }




        public Task<Livro> CadastrarLivroAsync(LivroViewModel livroViewModel)
        {
            throw new NotImplementedException();
        }




        public Task<bool> DeletarLivroAsync(int id)
        {
            throw new NotImplementedException();
        }




        public async Task<LivroResponseDto> ObterLivroPorIdAsync(int id)
        {
            var livro = await _livroRepository.ObterLivroPorIdAsync(id);
            return MapToLivroResponseDto(livro);
        }




        public async Task<List<LivroResponseDto>> ObterTodosLivrosAsync()
        {
            var livros = await _livroRepository.ObterTodosLivrosAsync();

            return livros.Select(MapToLivroResponseDto).ToList();
        }


        

        private LivroResponseDto MapToLivroResponseDto(Livro livro)
        {
            if (livro == null) 
                return null!;

            return new LivroResponseDto 
            { 
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                AnoPublicacao = livro.AnoPublicacao,
                Status = livro.Status,
                IdCategoria = livro.IdCategoria.Select(c => new CategoriaNomeDto { Nome = c.Nome}).ToList(),
            };


        }



    }
}
