using Microsoft.AspNetCore.Mvc;

namespace HastaneTakipSistemi.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
