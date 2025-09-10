using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.Models
{
    public class IndexViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<CalismaAlanlari> CalismaAlanlaris { get; set; }
        public List<Videolar> Videos { get; set; }
    }
}
