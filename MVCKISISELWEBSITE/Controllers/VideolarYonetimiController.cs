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
    public class VideolarYonetimiController : Controller
    {

        private readonly KisiselwebsiteContext _context; 

        public VideolarYonetimiController(KisiselwebsiteContext context)
        {
            _context = context;
        }

        // GET: VideolarYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videolars.ToListAsync());
        }

        // GET: VideolarYonetimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videolar = await _context.Videolars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videolar == null)
            {
                return NotFound();
            }

            return View(videolar);
        }

        // GET: VideolarYonetimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideolarYonetimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Yol,Sira,AktifMi")] Videolar videolar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videolar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videolar);
        }

        // GET: VideolarYonetimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videolar = await _context.Videolars.FindAsync(id);
            if (videolar == null)
            {
                return NotFound();
            }
            return View(videolar);
        }

        // POST: VideolarYonetimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yol,Sira,AktifMi")] Videolar videolar)
        {
            if (id != videolar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videolar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideolarExists(videolar.Id))
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
            return View(videolar);
        }

        // GET: VideolarYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videolar = await _context.Videolars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videolar == null)
            {
                return NotFound();
            }

            return View(videolar);
        }

        // POST: VideolarYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videolar = await _context.Videolars.FindAsync(id);
            if (videolar != null)
            {
                _context.Videolars.Remove(videolar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideolarExists(int id)
        {
            return _context.Videolars.Any(e => e.Id == id);
        }
    }
}
