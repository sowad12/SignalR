using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
