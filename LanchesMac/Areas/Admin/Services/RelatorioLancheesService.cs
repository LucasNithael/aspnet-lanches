using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.Services
{
    public class RelatorioLancheesService
    {
        private readonly AppDbContext _context;
        public RelatorioLancheesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Lanche>> GetLanchesReport()
        {
            var lanches = await _context.Lanche.ToListAsync();

            if (lanches is null)
            {
                return default(IEnumerable<Lanche>);
            }

            return lanches;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.Categoria.ToListAsync();

            if (categorias is null)
            {
                return default(IEnumerable<Categoria>);
            }

            return categorias;
        }
    }
}
