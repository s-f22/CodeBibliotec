using CodeBibliotec.Domains;

namespace CodeBibliotec.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObterPorEmailESenhaAsync(string email, string senha);

        Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId);
    }
}
