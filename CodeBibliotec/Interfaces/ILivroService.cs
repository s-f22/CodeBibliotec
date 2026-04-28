using CodeBibliotec.Domains;
using CodeBibliotec.ViewModels;


namespace CodeBibliotec.Interfaces
{
    public interface ILivroService
    {
        Task<LivroResponseDto> CadastrarLivroAsync(LivroViewModel livroViewModel);
        Task<LivroResponseDto> ObterLivroPorIdAsync(int id);
        Task<List<LivroResponseDto>> ObterTodosLivrosAsync();
        Task<bool> AtualizarLivroAsync(int id, LivroViewModel livroViewModel);
        Task<bool> DeletarLivroAsync(int id);
    }
}
