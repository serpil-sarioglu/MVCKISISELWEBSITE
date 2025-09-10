using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class Mesajlar
{
    public int Id { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Konu { get; set; } = null!;

    public string Mesaj { get; set; } = null!;
}
