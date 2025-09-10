using Microsoft.AspNetCore.Mvc;
using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.ViewComponents
{
    public class MakaleListViewComponent : ViewComponent
    {
        private KisiselwebsiteContext _context;
        public MakaleListViewComponent(KisiselwebsiteContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Makalelers.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList());
        }
    }
}
