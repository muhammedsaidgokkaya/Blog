using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace blog.ViewComponents.AdminKullaniciAdiListele
{
    public class AdminKullaniciAdiListele : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usernamesurname = c.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            ViewBag.adsoyad = usernamesurname;
            return View();
        }
    }
}