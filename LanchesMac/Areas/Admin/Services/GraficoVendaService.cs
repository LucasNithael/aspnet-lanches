using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.Services
{
    public class GraficoVendaService
    {
        private readonly AppDbContext _context;

        public GraficoVendaService(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetVendalanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in _context.PedidoDethales
                           join l in _context.Lanche on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome, pd.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LancheQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });


            var lista = new List<LancheGrafico>();

            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LancheQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
            }

            return lista;

        }

    }
}