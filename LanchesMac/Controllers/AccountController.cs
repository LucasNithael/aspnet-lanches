using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(
                new LoginViewModel()
                {
                    ReturnUrl = returnUrl
                }
                );
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM) //task representa uma operação assíncrona
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if(user != null)
            {
                // Primeiro false é para persistir o cockie de entrada quando o usuário fechar o navegador ;
                // O segundo false é para saber o usuário deve ser bloqueado caso o login ocorra valha
                var result = await _singInManager.PasswordSignInAsync(user, loginVM.Password, false, false);  
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl)) { 
                        return RedirectToAction("Index", "Home");
                    } 
                    return Redirect(loginVM.ReturnUrl);
                    
                }
            }
            ModelState.AddModelError("", "Falha ao realizar o login!!");
            return View(loginVM);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerVM.UserName };
                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded) return RedirectToAction("Login", "Account");
                else this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");

            }
            return View(registerVM);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
