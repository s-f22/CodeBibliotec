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



        public async Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId)
        {
            return await _usuarioRepository.UsuarioEhBibliotecariaAsync(usuarioId);
        }

        public async Task<Usuario?> ValidarEmailSenhaAsync(LoginViewModel login)
        {
            return await _usuarioRepository.ObterPorEmailESenhaAsync(login.Email, login.Senha);
        }
    }
}
