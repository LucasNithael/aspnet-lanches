using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories
{
    // Aqui definimos uma classe concreta
    public class CategoriaRepository : ICategoriaRepository
    {
        // Declaração de um campo privado para armazenar uma instância do contexto do banco de dados
        private readonly AppDbContext _context;

        // Construtor da classe que recebe uma instância de AppDbContext (injeção de dependência)
        public CategoriaRepository(AppDbContext context)
        {
            _context = context; // Atribui a instância do contexto recebida ao campo privado _context
        }

        // Propriedade que implementa a interface ICategoriaRepository, retornando as categorias do contexto
        public IEnumerable<Categoria> Categorias => _context.Categoria;
    }
}
