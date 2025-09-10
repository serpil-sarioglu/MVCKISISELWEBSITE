using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class Makaleler
{
    public int Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public bool AktifMi { get; set; }

    public int Sira { get; set; }

    public int LikeCount { get; set; }

    public int DislikeCount { get; set; }

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
