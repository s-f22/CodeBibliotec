using CodeBibliotec.Domains;

namespace CodeBibliotec.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categorium> CadastrarCategoriaAsync(Categorium categoria);
        Task<List<Categorium>> ObterTodasCategoriasAsync();
        Task<Categorium> ObterCategoriaPorIdAsync(int id);
    }
}
