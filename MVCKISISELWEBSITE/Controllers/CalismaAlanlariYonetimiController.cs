using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCKISISELWEBSITE.DAL;
using MVCKISISELWEBSITE.Filters;

namespace MVCKISISELWEBSITE.Controllers
{
    [ServiceFilter(typeof(LoginFilter))]
    public class CalismaAlanlariYonetimiController : Controller
    {
        private readonly KisiselwebsiteContext _context;

        public CalismaAlanlariYonetimiController(KisiselwebsiteContext context)
        {
            _context = context;
        }

        // GET: CalismaAlanlariYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalismaAlanlaris.ToListAsync());
        }

        // GET: CalismaAlanlariYonetimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calismaAlanlari = await _context.CalismaAlanlaris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calismaAlanlari == null)
            {
                return NotFound();
            }

            return View(calismaAlanlari);
        }

        // GET: CalismaAlanlariYonetimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalismaAlanlariYonetimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik,AktifMi,Sira")] CalismaAlanlari calismaAlanlari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calismaAlanlari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calismaAlanlari);
        }

        // GET: CalismaAlanlariYonetimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calismaAlanlari = await _context.CalismaAlanlaris.FindAsync(id);
            if (calismaAlanlari == null)
            {
                return NotFound();
            }
            return View(calismaAlanlari);
        }

        // POST: CalismaAlanlariYonetimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik,AktifMi,Sira")] CalismaAlanlari calismaAlanlari)
        {
            if (id != calismaAlanlari.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calismaAlanlari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalismaAlanlariExists(calismaAlanlari.Id))
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
            return View(calismaAlanlari);
        }

        // GET: CalismaAlanlariYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calismaAlanlari = await _context.CalismaAlanlaris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calismaAlanlari == null)
            {
                return NotFound();
            }

            return View(calismaAlanlari);
        }

        // POST: CalismaAlanlariYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calismaAlanlari = await _context.CalismaAlanlaris.FindAsync(id);
            if (calismaAlanlari != null)
            {
                _context.CalismaAlanlaris.Remove(calismaAlanlari);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalismaAlanlariExists(int id)
        {
            return _context.CalismaAlanlaris.Any(e => e.Id == id);
        }
    }
}
