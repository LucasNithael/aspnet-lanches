using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepository: ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        // include - Métodos que permite obter os dados relacionados incluindo-os no resultado da consulta
        public IEnumerable<Lanche> Lanches => _context.Lanche.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanche.Where(p =>
        p.IsLanchePreferido).Include(c =>c.Categoria);

        //FirstOrDefault - retorna o primeiro elemento de uma sequência ou um valor padrão caso não seja encontrado nenhum elemento
        public Lanche GetLanche(int lancheId) => _context.Lanche.FirstOrDefault(l => l.LancheId == lancheId);
    }
}
