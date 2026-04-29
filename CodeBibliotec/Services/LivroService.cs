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




        public async Task<bool> AtualizarLivroAsync(int id, LivroViewModel livroViewModel)
        {
            var livro = new Livro
            {
                Id = id,
                Titulo = livroViewModel.Titulo,
                Autor = livroViewModel.Autor,
                AnoPublicacao = livroViewModel.AnoPublicacao,

                Status = string.IsNullOrWhiteSpace(livroViewModel.Status)
                    ? "Disponível"
                    : livroViewModel.Status.Trim()
            };

            if (livroViewModel.CategoriaIds != null)
            {
                livro.IdCategoria = livroViewModel.CategoriaIds
                    .Select(id => new Categorium { Id = id, Nome = string.Empty})
                    .ToList();
            }

            return await _livroRepository.AtualizarLivroAsync(id, livro);

        }




        public async Task<LivroResponseDto> CadastrarLivroAsync(LivroViewModel livroViewModel)
        {
            var livro = new Livro
            {
                Titulo = livroViewModel.Titulo,
                Autor = livroViewModel.Autor,
                AnoPublicacao = livroViewModel.AnoPublicacao,

                Status = string.IsNullOrWhiteSpace(livroViewModel.Status)
                    ? "Disponível"
                    : livroViewModel.Status.Trim()

            };

            if (livroViewModel.CategoriaIds != null && livroViewModel.CategoriaIds.Any())
            {
                livro.IdCategoria = livroViewModel.CategoriaIds
                    .Select(id => new Categorium { Id = id, Nome = string.Empty}).ToList();
            }

            var response = await _livroRepository.CadastrarLivroAsync(livro);

            return MapToLivroResponseDto(response);


        }




        public async Task<bool> DeletarLivroAsync(int id)
        {
            return await _livroRepository.DeletarLivroAsync(id);
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
