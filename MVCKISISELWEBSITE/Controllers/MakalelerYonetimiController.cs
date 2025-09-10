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
    public class MakalelerYonetimiController : Controller
    {
        private readonly KisiselwebsiteContext _context;

        public MakalelerYonetimiController(KisiselwebsiteContext context)
        {
            _context = context;
        }

        // GET: MakalelerYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Makalelers.ToListAsync());
        }

        // GET: MakalelerYonetimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makaleler = await _context.Makalelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makaleler == null)
            {
                return NotFound();
            }

            return View(makaleler);
        }

        // GET: MakalelerYonetimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MakalelerYonetimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik,AktifMi,Sira")] Makaleler makaleler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(makaleler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(makaleler);
        }

        // GET: MakalelerYonetimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makaleler = await _context.Makalelers.FindAsync(id);
            if (makaleler == null)
            {
                return NotFound();
            }
            return View(makaleler);
        }

        // POST: MakalelerYonetimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik,AktifMi,Sira")] Makaleler makaleler)
        {
            if (id != makaleler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makaleler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakalelerExists(makaleler.Id))
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
            return View(makaleler);
        }

        // GET: MakalelerYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makaleler = await _context.Makalelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makaleler == null)
            {
                return NotFound();
            }

            return View(makaleler);
        }

        // POST: MakalelerYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makaleler = await _context.Makalelers.FindAsync(id);
            if (makaleler != null)
            {
                _context.Makalelers.Remove(makaleler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakalelerExists(int id)
        {
            return _context.Makalelers.Any(e => e.Id == id);
        }
    }
}
