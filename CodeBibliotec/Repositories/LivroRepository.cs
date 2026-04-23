
using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Repositories
{
    public class LivroRepository : ILivroRepository
    {

        private readonly BibliotecContext _context;

        // Metodo construtor para injetar a camada de contexto no repository
        public LivroRepository(BibliotecContext context)
        {
            _context = context;
        }




        public Task<bool> AtualizarLivroAsync(int id, Livro livro)
        {
            throw new NotImplementedException();
        }



        public async Task<Livro> CadastrarLivroAsync(Livro livro)
        {
            if (livro.IdCategoria != null && livro.IdCategoria.Any())
            {
                var categoriaIds = livro.IdCategoria.Select(c => c.Id).ToList();

                livro.IdCategoria = await _context.Categoria.Where(c => categoriaIds.Contains(c.Id)).ToListAsync();
            }

            _context.Livros.Add(livro);

            await _context.SaveChangesAsync();

            return livro;

        }



        public Task<bool> DeletarLivroAsync(int id)
        {
            throw new NotImplementedException();
        }




        public async Task<Livro> ObterLivroPorIdAsync(int id)
        {
            return await _context.Livros.Include(l => l.IdCategoria).FirstOrDefaultAsync(l => l.Id == id);
        }




        public async Task<List<Livro>> ObterTodosLivrosAsync()
        {
            return await _context.Livros
                .Include(l => l.IdCategoria)
                .ToListAsync();
        }



    }
}
