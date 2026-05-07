using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecContext _context;

        public UsuarioRepository(BibliotecContext context)
        {
            _context = context;
        }




        public async Task<Usuario?> ObterPorEmailESenhaAsync(string email, string senha)
        {
            return await _context.Usuarios
                .Include(u => u.Aluno)
                .Include(u => u.Bibliotecarium)
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId)
        {
            return await _context.Bibliotecaria.AnyAsync(b => b.IdUsuario == usuarioId);
        }
    }
}
