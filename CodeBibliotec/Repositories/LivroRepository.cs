
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



        public Task<Livro> CadastrarLivroAsync(Livro livro)
        {
            throw new NotImplementedException();
        }



        public Task<bool> DeletarLivroAsync(int id)
        {
            throw new NotImplementedException();
        }




        public Task<Livro> ObterLivroPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }




        public Task<List<Livro>> ObterTodosLivrosAsync()
        {
            return _context.Livros.Include(l => l.IdCategoria).ToListAsync();
        }



    }
}
