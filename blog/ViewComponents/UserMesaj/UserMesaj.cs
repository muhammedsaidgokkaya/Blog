using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.UserMesaj
{
    public class UserMesaj : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var a = c.UserMesajs.ToList();
            return View(a);
        }
    }
}