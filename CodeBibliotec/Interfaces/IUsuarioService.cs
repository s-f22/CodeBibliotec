using CodeBibliotec.Domains;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> ValidarEmailSenhaAsync(LoginViewModel login);
        Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId);
    }
}
