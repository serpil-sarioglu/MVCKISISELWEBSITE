using Microsoft.AspNetCore.Mvc;
using MVCKISISELWEBSITE.DAL;
using MVCKISISELWEBSITE.Filters;
using MVCKISISELWEBSITE.Models;
using NuGet.Protocol.Plugins;

namespace MVCKISISELWEBSITE.Controllers
{
    public class AdminController : Controller
    {
        private readonly KisiselwebsiteContext db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AdminController(KisiselwebsiteContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            _hostEnvironment = hostEnvironment;
        }

        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains("userName"))
            {
                return RedirectToAction("Login");
            }
            var user = HttpContext.Session.GetString("userName");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var kullanici= db.Kullanicis.Where(h=>h.Sifre == model.Password && h.Email==model.UserName).SingleOrDefault();
            if(kullanici != null)
            {
                HttpContext.Session.SetString("userName", model.UserName);
                return RedirectToAction("Index");
            }
            ViewBag.mesaj = "hatalı giriş yapıldı";
            return View();
        }
        public IActionResult Dosyalarim()
        {
            string p = Path.Combine(_hostEnvironment.WebRootPath, "img");
            List<string> imgfiles = Directory.GetFiles(p).Select(Path.GetFileName).ToList();
            return View(imgfiles);
        }
        [HttpPost]
        public IActionResult Dosyalarim(IFormFile file)
        {

            if (file != null && file.Length != 0)
            {
                var fd = "\\wwwroot\\img\\" + file.FileName;
                var filePath = _hostEnvironment.ContentRootPath + fd;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }

            string p = Path.Combine(_hostEnvironment.WebRootPath, "img");
            List<string> imgfiles = Directory.GetFiles(p).Select(Path.GetFileName).ToList();


            return View(imgfiles);
        }

        [HttpPost]
        public IActionResult DosyalarimSil(string fileName)
        {
           
            if (fileName != null && fileName.Length != 0)
            {

                string p = Path.Combine(_hostEnvironment.WebRootPath, "img", "\\wwwroot\\img\\" + fileName);
                // Dosya mevcutsa sil
                if (System.IO.File.Exists(p))
                {
                    System.IO.File.Delete(p);
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Dosya bulunamadı.");
                }                
            }
            else
            {
                // File doesn't exist
                return NotFound();
            }
        }

    }
}
