using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCKISISELWEBSITE.DAL;
using MVCKISISELWEBSITE.Filters;
using NuGet.Protocol.Plugins;

namespace MVCKISISELWEBSITE.Controllers
{
    [ServiceFilter(typeof(LoginFilter))]
    public class KadromuzYonetimiController : Controller
    {
        private readonly KisiselwebsiteContext _context;
        private readonly IHostEnvironment _hostEnvironment;

        public KadromuzYonetimiController(KisiselwebsiteContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: KadromuzYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kadromuzs.ToListAsync());
        }

        // GET: KadromuzYonetimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kadromuz = await _context.Kadromuzs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kadromuz == null)
            {
                return NotFound();
            }

            return View(kadromuz);
        }

        // GET: KadromuzYonetimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KadromuzYonetimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,Unvan,Yol,AktifMi")] Kadromuz kadromuz, IFormFile file)
        {

            if (file != null && file.Length != 0)
            {
                var fd = "\\wwwroot\\img\\" + file.FileName;
                var filePath = _hostEnvironment.ContentRootPath + fd;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                kadromuz.Yol = "/img/" + file.FileName;
            }
            if (ModelState.IsValid)
            {
                _context.Add(kadromuz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kadromuz);
        }

        // GET: KadromuzYonetimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kadromuz = await _context.Kadromuzs.FindAsync(id);
            if (kadromuz == null)
            {
                return NotFound();
            }
            return View(kadromuz);
        }

        // POST: KadromuzYonetimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,Unvan,Yol,AktifMi")] Kadromuz kadromuz, IFormFile file)
        {
            if (file != null && file.Length != 0)
            {
                var fd = "\\wwwroot\\img\\" + file.FileName;
                var filePath = _hostEnvironment.ContentRootPath + fd;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                kadromuz.Yol = "/img/" + file.FileName;
            }
            if (id != kadromuz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kadromuz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KadromuzExists(kadromuz.Id))
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
            return View(kadromuz);
        }

        // GET: KadromuzYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kadromuz = await _context.Kadromuzs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kadromuz == null)
            {
                return NotFound();
            }

            return View(kadromuz);
        }

        // POST: KadromuzYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kadromuz = await _context.Kadromuzs.FindAsync(id);
            if (kadromuz != null)
            {
                _context.Kadromuzs.Remove(kadromuz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KadromuzExists(int id)
        {
            return _context.Kadromuzs.Any(e => e.Id == id);
        }
    }
}
