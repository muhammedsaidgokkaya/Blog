using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blog.ViewComponents.CategoriListOne
{
    public class CategoryListOne : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var a = c.Categories.ToList();
            return View(a);
        }
    }
}