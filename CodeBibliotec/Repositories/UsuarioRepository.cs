using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;

namespace CodeBibliotec.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecContext _context;

        public UsuarioRepository(BibliotecContext context)
        {
            _context = context;
        }




        public Task<Usuario?> ObterPorEmailESenhaAsync(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
