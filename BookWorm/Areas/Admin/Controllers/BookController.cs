using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
