using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class Yorumlar
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public int? ParentId { get; set; }

    public DateTime Tarih { get; set; }

    public int MakaleId { get; set; }

    public virtual ICollection<Yorumlar> InverseParent { get; set; } = new List<Yorumlar>();

    public virtual Makaleler Makale { get; set; } = null!;

    public virtual Yorumlar? Parent { get; set; }
}
