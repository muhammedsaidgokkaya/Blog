using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eticaret.ViewComponents.ReferansListele
{
    public class ReferansListele : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var referanslistesi = c.Referanslars.ToList();
            return View(referanslistesi);
        }
    }
}