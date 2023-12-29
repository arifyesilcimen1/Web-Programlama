using HastaneTakipSistemi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Goruntule(string userInput)
        {
            /* var barkod= _context.barkodOlusturs.FirstOrDefault(a=> a.tcNo == tc);
             var gorunutle = _context.hastaYapilanIslemlers.Where(x=> x.barkodOlusturId== barkod.Id).ToList();


             return View(gorunutle);*/
            // Veritabanından gelen tcKimlik'e sahip BarkodOlustur nesnesini bul
            /*
             *  var hastaYapilanIslemler = await _context.hastaYapilanIslemlers
                .Include(h => h.barkodOlustur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaYapilanIslemler == null)
            {
                return NotFound();
            }

            return View(hastaYapilanIslemler);
             */
            var hasta = _context.barkodOlusturs
                                .Include(b => b.hastaYapilanIslemlers) // İlgili HastaYapilanIslemler'ı getir
                                .FirstOrDefault(b => b.tcNo == userInput);


            // Eğer hasta bulunduysa, hastaYapilanIslemlers listesini kullanabilirsiniz
            var yapilanIslemler = hasta.hastaYapilanIslemlers.ToList();

            // Diğer işlemleri gerçekleştirin veya view'a gönderin
            return View(yapilanIslemler);


        }


    }
}
