using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneTakipSistemi.Data;
using HastaneTakipSistemi.Models;

namespace HastaneTakipSistemi.Controllers
{
    public class BarkodOlustursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarkodOlustursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BarkodOlusturs
        public async Task<IActionResult> Index()
        {
              return _context.barkodOlusturs != null ? 
                          View(await _context.barkodOlusturs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.barkodOlusturs'  is null.");
        }

        // GET: BarkodOlusturs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.barkodOlusturs == null)
            {
                return NotFound();
            }

            var barkodOlustur = await _context.barkodOlusturs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barkodOlustur == null)
            {
                return NotFound();
            }

            return View(barkodOlustur);
        }

        // GET: BarkodOlusturs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BarkodOlusturs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HastaAdi,tcNo,EngelDurumu,Yas,Kod")] BarkodOlustur barkodOlustur)
        {
            barkodOlustur.BarkodNumarasi = _context.barkodOlusturs.OrderByDescending(x => x.Id).Select(x => x.BarkodNumarasi).FirstOrDefault();
            if (barkodOlustur.Yas>=65 ||barkodOlustur.Yas<12 || barkodOlustur.EngelDurumu==true)
            {
                barkodOlustur.BarkodNumarasi *= 10000; //buradaki 10000 öncelikli hastayı temsil eder
            }
            

            _context.Add(barkodOlustur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: BarkodOlusturs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.barkodOlusturs == null)
            {
                return NotFound();
            }

            var barkodOlustur = await _context.barkodOlusturs.FindAsync(id);
            if (barkodOlustur == null)
            {
                return NotFound();
            }
            return View(barkodOlustur);
        }

        // POST: BarkodOlusturs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HastaAdi,tcNo,EngelDurumu,Yas,BarkodNumarasi,Kod")] BarkodOlustur barkodOlustur)
        {
            if (id != barkodOlustur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barkodOlustur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarkodOlusturExists(barkodOlustur.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(barkodOlustur);
        }

        // GET: BarkodOlusturs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.barkodOlusturs == null)
            {
                return NotFound();
            }

            var barkodOlustur = await _context.barkodOlusturs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barkodOlustur == null)
            {
                return NotFound();
            }

            return View(barkodOlustur);
        }

        // POST: BarkodOlusturs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.barkodOlusturs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.barkodOlusturs'  is null.");
            }
            var barkodOlustur = await _context.barkodOlusturs.FindAsync(id);
            if (barkodOlustur != null)
            {
                _context.barkodOlusturs.Remove(barkodOlustur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarkodOlusturExists(int id)
        {
          return (_context.barkodOlusturs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
