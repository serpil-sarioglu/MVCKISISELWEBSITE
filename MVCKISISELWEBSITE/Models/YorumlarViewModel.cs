using MVCKISISELWEBSITE.DAL;

namespace MVCKISISELWEBSITE.Models
{
    public class YorumlarViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Icerik { get; set; } = null!;

        public int? ParentId { get; set; }

        public DateTime Tarih { get; set; }

        public int MakaleId { get; set; }

        public List<Yorumlar> InverseParent { get; set; } = new List<Yorumlar>();

        public Makaleler Makale { get; set; } = null!;

        public virtual Yorumlar? Parent { get; set; }


    }
}
