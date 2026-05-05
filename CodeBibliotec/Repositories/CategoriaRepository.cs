using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly BibliotecContext _context;

        public CategoriaRepository(BibliotecContext context)
        {
            _context = context;
        }




        public async Task<Categorium> CadastrarCategoriaAsync(Categorium categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }



        public async Task<List<Categorium>> ObterTodasCategoriasAsync()
        {
            return await _context.Categoria
                .Include(c => c.IdLivros) // inclui os objetos do tipo Livro, relacionados
                .ToListAsync();
        }



        public async Task<Categorium> ObterCategoriaPorIdAsync(int id)
        {
            return await _context.Categoria
                .Include(c => c.IdLivros)
                .FirstOrDefaultAsync(c => c.Id == id);
        }



    }
}
