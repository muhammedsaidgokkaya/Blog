using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.AdminMesaj
{
    public class AdminMesaj : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var a = c.AdminMesajs.ToList();
            return View(a);
        }
    }
}