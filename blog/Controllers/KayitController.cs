using blog.Models;
using blog.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Controllers
{
    public class KayitController : Controller
    {
        private readonly ILogger<KayitController> _logger;
        private readonly UserManager<AppUser> _usermanager;
        private readonly RoleManager<AppRole> _rolemanager;

        public KayitController(ILogger<KayitController> logger, UserManager<AppUser> usermanager, RoleManager<AppRole> rolemanager)
        {
            _logger = logger;
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(KullaniciKayitDto kayit)
        {
            Context c = new Context();
            if (ModelState.IsValid)
            {
                if (kayit.confirmpassword == kayit.password)
                {
                    AppUser user = new AppUser()
                    {
                        Email = kayit.mail,
                        UserName = kayit.username,
                        namesurname = kayit.namesurname,
                        Adres1 = kayit.Adres1,
                        Adres2=kayit.Adres2,
                        Adres3 = kayit.Adres3,
                    };
                    var result = await _usermanager.CreateAsync(user, kayit.password);
                    if (result.Succeeded)
                    {
                        var defaultrole = "Uye";
                        if (defaultrole != null)
                        {
                            IdentityResult roleresult = await _usermanager.AddToRoleAsync(user, defaultrole);
                        }
                    }
                    return RedirectToAction("Index", "Giris");
                }
                else
                {
                    ViewBag.hatamesaji = "Hatalı Kayıt";
                    return View();
                }
            }
            else
            {
                ViewBag.hatamesaji = "Hatalı Kayıt";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
