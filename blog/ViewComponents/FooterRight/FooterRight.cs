using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.FooterRight
{
    public class FooterRight : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Iletisims.ToList();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Adres = list.Adres.ToString();
            return View(liste);
        }
    }
}
