using HastaneTakipSistemi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneTakipSistemi.Controllers
{
    public class YapılanIslemGoruntule : Controller
    {
        private readonly ApplicationDbContext _context;

        public YapılanIslemGoruntule(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YapılanIslemGoruntule
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Goruntule(int barkodId)
        {
            var gorunutle = _context.hastaYapilanIslemlers.Where(x => x.barkodOlusturId == barkodId).ToList();


            return View(gorunutle);
        }

       
    }
}
