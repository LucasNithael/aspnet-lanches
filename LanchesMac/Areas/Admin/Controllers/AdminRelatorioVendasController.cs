using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendaService relatorioVendasService;

        public AdminRelatorioVendasController(RelatorioVendaService relatorioVendasService)
        {
            this.relatorioVendasService = relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyyy-MM-dd");

            var result = await relatorioVendasService.FindByDateAsync(minDate, maxDate);
            return View(result);


        }
    }
}
