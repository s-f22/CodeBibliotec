using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }



        public Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> ValidarEmailSenhaAsync(LoginViewModel login)
        {
            throw new NotImplementedException();
        }
    }
}
