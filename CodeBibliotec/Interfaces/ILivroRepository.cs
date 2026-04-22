

using CodeBibliotec.Domains;

namespace CodeBibliotec.Interfaces
{
    public interface ILivroRepository
    {
        Task<Livro> CadastrarLivroAsync(Livro livro);
        Task<Livro> ObterLivroPorIdAsync(int id);
        Task<List<Livro>> ObterTodosLivrosAsync();
        Task<bool> AtualizarLivroAsync(int id, Livro livro);
        Task<bool> DeletarLivroAsync(int id);
    }
}
