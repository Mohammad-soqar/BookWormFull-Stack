using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
