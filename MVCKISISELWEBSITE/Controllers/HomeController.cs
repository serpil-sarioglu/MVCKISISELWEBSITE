using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCKISISELWEBSITE.DAL;
using MVCKISISELWEBSITE.Filters;
using MVCKISISELWEBSITE.Models;
using System.Diagnostics;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCKISISELWEBSITE.Controllers
{
    //[ServiceFilter(typeof(LogFilter))]
    public class HomeController : Controller
    {
        KisiselwebsiteContext db;

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, KisiselwebsiteContext db)
        {
            _logger = logger;
            this.db = db;

        }

        public IActionResult Index()
        {
            var sliders = db.Sliders.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            var calismaAlanlari = db.CalismaAlanlaris.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            var videolar = db.Videolars.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            IndexViewModel model = new IndexViewModel();
            model.Sliders = sliders;
            model.CalismaAlanlaris = calismaAlanlari;
            model.Videos = videolar;
            return View(model);
        }
        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult CalismaAlanlari(int id)
        {
            var calismaAlanlari = db.CalismaAlanlaris.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            //id null gelmez sýfýr gelir hata vermesin ilk kayýt çalýþmasý içindir. 
            if (id == 0)
            {
                ViewBag.Icerik = calismaAlanlari.FirstOrDefault().Icerik;
                ViewBag.Baslik = calismaAlanlari.FirstOrDefault().Baslik;
            }
            else
            {
                ViewBag.Icerik = calismaAlanlari.SingleOrDefault(h => h.Id == id).Icerik;
                ViewBag.Baslik = calismaAlanlari.SingleOrDefault(h => h.Id == id).Baslik;
            }

            return View(calismaAlanlari);
        }
        public IActionResult Makaleler()
        {
            var makaleler = db.Makalelers.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();

            return View(makaleler);
        }
        public IActionResult MakalelerDetay(int id)
        {
            var makaleler = db.Makalelers.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();


            //var yorumlar = db.Makalelers.Include(m => m.Yorumlars).SingleOrDefault(m => m.Id == id)?.Yorumlars.ToList();


            if (id == 0)
            {
                //ViewBag.Icerik = makaleler.FirstOrDefault().Icerik;
                //ViewBag.Baslik = makaleler.FirstOrDefault().Baslik;
                ViewBag.Makale = makaleler.FirstOrDefault();
                ViewBag.MakaleYorum = db.Makalelers.Include(m => m.Yorumlars).SingleOrDefault(m => m.Id == id)?.Yorumlars;

            }
            else
            {
                //ViewBag.Icerik = makaleler.SingleOrDefault(h => h.Id == id).Icerik;
                //ViewBag.Baslik = makaleler.SingleOrDefault(h => h.Id == id).Baslik;
                ViewBag.Makale = makaleler.SingleOrDefault(h => h.Id == id);
                ViewBag.MakaleYorum = db.Makalelers.Include(m => m.Yorumlars).SingleOrDefault(m => m.Id == id)?.Yorumlars;
            }
            
            return View(makaleler);
        }
        [HttpPost]
        public IActionResult YorumYap(YorumlarViewModel formData)
        {
            try
            {
                Yorumlar yorum = new Yorumlar();
                yorum.MakaleId = formData.MakaleId;

                if (formData.ParentId.HasValue)
                {
                    yorum.ParentId = formData.ParentId;
                    yorum.InverseParent = (ICollection<Yorumlar>)db.Yorumlars.Find(formData.ParentId);
                }
                else
                {
                    yorum.ParentId = null;
                    yorum.InverseParent = null;
                }
                yorum.Email = formData.Email;
                yorum.Icerik = formData.Icerik;
                yorum.Tarih = DateTime.Now;

                db.Yorumlars.Add(yorum);
                db.SaveChanges();
                return Json(new { IsSuccess = true });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, ErrorMessage = ex + " Yorumunuz kaydedilirken bir hata oluþtu" });
            }
        }

        public IActionResult Kadromuz()
        {
            var kadromuz = db.Kadromuzs.Where(h => h.AktifMi).ToList();
            return View(kadromuz);
        }
        public IActionResult Iletisim()
        {
            //throw   new Exception("özel hata");
            return View(db.GenelBilgis.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Mesaj(MesajViewModel formData)
        {
            if (ModelState.IsValid)
            {
                Mesajlar mesaj = new Mesajlar();
                mesaj.AdSoyad = formData.adSoyad;
                mesaj.Mesaj = formData.mesaj;
                mesaj.Konu = formData.konu;
                db.Mesajlars.Add(mesaj);
                db.SaveChanges();
                return Json("Form baþarýyla kaydedildi");
            }
            return Json("Form gönderilirken hata oluþtu");

        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult Like(int Id)
        {
            var m = db.Makalelers.Find(Id);
            m.LikeCount++;
            db.SaveChanges();

            return Json(m.LikeCount);
        }

        [HttpPost]
        public JsonResult DisLike(int Id)
        {
            var m = db.Makalelers.Find(Id);
            m.DislikeCount++;
            db.SaveChanges();
            return Json(m.DislikeCount);
        }
    }
}
