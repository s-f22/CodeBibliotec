using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using CodeBibliotec.Utils;
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
            var usuario = await _context.Usuarios
                .Include(u => u.Aluno)
                .Include(u => u.Bibliotecarium)
                .FirstOrDefaultAsync(u => u.Email == email);

            if(usuario == null)
                return null;

            if (SenhaUtils.EstaHashada(usuario.Senha))
            {
                if (SenhaUtils.VerificarSenha(senha, usuario.Senha))
                    return usuario;

                return null;
            }
            else
            {
                if(usuario.Senha == senha)
                {
                    usuario.Senha = SenhaUtils.HashSenha(senha);
                    await _context.SaveChangesAsync();
                    return usuario;
                }
                return null;
            }

        }

        public async Task<bool> UsuarioEhBibliotecariaAsync(int usuarioId)
        {
            return await _context.Bibliotecaria.AnyAsync(b => b.IdUsuario == usuarioId);
        }
    }
}
