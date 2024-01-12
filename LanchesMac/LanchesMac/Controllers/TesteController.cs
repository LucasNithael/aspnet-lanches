using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class TesteController1cs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
