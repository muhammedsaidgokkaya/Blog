using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.KategoriMenu
{
    public class KategoriMenu : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var a = c.Categories.ToList();
            return View(a);
        }
    }
}