using Microsoft.AspNetCore.Mvc;
using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.ViewComponents
{
    public class SocialIconListViewComponent : ViewComponent
    {
        private KisiselwebsiteContext _context;
        public SocialIconListViewComponent(KisiselwebsiteContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.GenelBilgis.FirstOrDefault());
        }
    }
}
