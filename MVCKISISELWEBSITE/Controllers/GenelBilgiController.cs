using Microsoft.AspNetCore.Mvc;
using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.Controllers
{
    public class GenelBilgiController : Controller
    {
        private KisiselwebsiteContext _context;
        public GenelBilgiController(KisiselwebsiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   //genel bilgi tablosunun ilk kaydını bize getirsin ve view sayfasına göndersin
            return View(_context.GenelBilgis.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Index(GenelBilgi model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return View(model);
        }
    }
}
