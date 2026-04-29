
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




        public async Task<bool> AtualizarLivroAsync(int id, Livro livro)
        {
            var livroExistente = await _context.Livros
                .Include(l => l.IdCategoria)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livroExistente == null)
                return false;

            livroExistente.Titulo = livro.Titulo;
            livroExistente.Autor = livro.Autor;
            livroExistente.AnoPublicacao = livro.AnoPublicacao;
            livroExistente.Status = livro.Status;

            if (livro.IdCategoria != null)
            {
                var categoriaIds = livro.IdCategoria.Select(c => c.Id).ToList();

                var categorias = await _context.Categoria
                    .Where(c => categoriaIds.Contains(c.Id))
                    .ToListAsync();

                livroExistente.IdCategoria.Clear();

                foreach (var categoria in categorias)
                {
                    livroExistente.IdCategoria.Add(categoria);
                }

            }

            _context.Livros.Update(livroExistente);

            await _context.SaveChangesAsync();

            return true;

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



        public async Task<bool> DeletarLivroAsync(int id)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return true;
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
