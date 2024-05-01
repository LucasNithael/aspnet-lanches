using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using LanchesMac.Areas.Admin.FastReportUtils;
using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class AdminLanchesReportController(IWebHostEnvironment webHostEnvironment,
        RelatorioLancheesService relatorioLanchesService) : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv = webHostEnvironment;
        private readonly RelatorioLancheesService _relatorioLanchesService = relatorioLanchesService;

        [Route("LanchesCategoriaReport")]
        public async Task<ActionResult> LanchesCategoriaReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "lanchesCategoria.frx"));

            var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(),
                "LanchesReport");

            var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(),
                "CategoriasReport");

            webReport.Report.RegisterData(lanches, "LanchesReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            return View(webReport);
        }

        [Route("LanchesCategoriaPDF")]
        public async Task<ActionResult> LanchesCategoriaPDF()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "lanchesCategoria.frx"));

            var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(),
                "LanchesReport");

            var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(),
                "CategoriasReport");

            webReport.Report.RegisterData(lanches, "LanchesReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            //return File(stream, "application/zip", "LanchesCategoria.pdf"); //faz download do pdf
            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
