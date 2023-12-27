using Microsoft.AspNetCore.Mvc;

namespace HastaneTakipSistemi.Controllers
{
    public class AcilEkranController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
