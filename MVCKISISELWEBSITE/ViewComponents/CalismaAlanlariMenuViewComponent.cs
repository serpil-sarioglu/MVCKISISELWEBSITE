using Microsoft.AspNetCore.Mvc;
using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.ViewComponents
{
    public class CalismaAlanlariMenuViewComponent:ViewComponent
    {
        private readonly KisiselwebsiteContext _db;
        public CalismaAlanlariMenuViewComponent(KisiselwebsiteContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var basliklar= _db.CalismaAlanlaris.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            return View(basliklar);
        }
    }
}
