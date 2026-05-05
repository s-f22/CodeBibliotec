using CodeBibliotec.Domains;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaResponseDto> CadastrarCategoriaAsync(CategoriaViewModel categoriaViewModel);
        Task<List<CategoriaResponseDto>> ObterTodasCategoriasAsync();
        Task<CategoriaResponseDto> ObterCategoriaPorIdAsync(int id);
    }
}
