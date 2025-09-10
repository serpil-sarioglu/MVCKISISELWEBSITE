using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.Controllers
{
    public class MesajlarYonetimiController : Controller
    {
        private readonly KisiselwebsiteContext _context;

        public MesajlarYonetimiController(KisiselwebsiteContext context)
        {
            _context = context;
        }

        // GET: MesajlarYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesajlars.ToListAsync());
        }   

        // GET: MesajlarYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesajlar = await _context.Mesajlars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesajlar == null)
            {
                return NotFound();
            }

            return View(mesajlar);
        }

        // POST: MesajlarYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesajlar = await _context.Mesajlars.FindAsync(id);
            if (mesajlar != null)
            {
                _context.Mesajlars.Remove(mesajlar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesajlarExists(int id)
        {
            return _context.Mesajlars.Any(e => e.Id == id);
        }
    }
}
