using blog.Enums;
using blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Controllers
{
    public class GirisController : Controller
    {
        private readonly ILogger<GirisController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public GirisController(ILogger<GirisController> logger, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(KullaniciGirisDto girisbilgileri)
        {
            Context context = new Context();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(girisbilgileri.username, girisbilgileri.password, false, true);

                if (result.Succeeded)
                {
                    var name = context.Users.Where(x => x.UserName == girisbilgileri.username).Select(y => y.namesurname).FirstOrDefault();
                    var userid = context.Users.Where(x => x.namesurname == name).Select(y => y.Id).FirstOrDefault();

                    var UserRole = context.UserRoles.Where(x => x.UserId == userid).FirstOrDefault();
                    var roleType = context.Roles.Where(x => x.Id == UserRole.RoleId).Select(y => y.RolType).FirstOrDefault();

                    if(roleType == (int)UserRolTypeEnum.Uye)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else if(roleType == (int)UserRolTypeEnum.Admin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Giris");
                }
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Giris");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
