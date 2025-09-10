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
    public class SliderYonetimiController : Controller
    {
        //private readonly KisiselwebsiteContext _context;
        KisiselwebsiteContext _context;
        private readonly IHostEnvironment _hostEnvironment;
        public SliderYonetimiController(KisiselwebsiteContext context, IHostEnvironment ev)
        {
            _context = context;
            _hostEnvironment = ev;
        }

        // GET: SliderYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: SliderYonetimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: SliderYonetimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SliderYonetimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Yol,Sira,AktifMi")] Slider slider,IFormFile file)
        {
            if (file != null && file.Length !=0)
            {
                var fd = "\\wwwroot\\img\\"+file.FileName;
                var filePath = _hostEnvironment.ContentRootPath +fd;
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                slider.Yol = "/img/"+file.FileName;
            }


            if (ModelState.IsValid)
            {
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: SliderYonetimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: SliderYonetimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yol,Sira,AktifMi")] Slider slider, IFormFile file)
        {
            if (file != null && file.Length != 0)
            {
                var fd = "\\wwwroot\\img\\" + file.FileName;
                var filePath = _hostEnvironment.ContentRootPath + fd;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                slider.Yol = "/img/" + file.FileName;
            }

            if (id != slider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.Id))
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
            return View(slider);
        }

        // GET: SliderYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: SliderYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.Id == id);
        }
    }
}
