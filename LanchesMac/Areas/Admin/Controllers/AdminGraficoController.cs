using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendaService _graficoVendas;

        public AdminGraficoController(GraficoVendaService graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendas.GetVendalanches(dias);
            return Json(lanchesVendasTotais);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VendasMensal(int dias)
        {
            return View();
        }
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }
    }
}
