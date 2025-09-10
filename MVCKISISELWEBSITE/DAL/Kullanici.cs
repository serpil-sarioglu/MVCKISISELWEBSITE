using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class Kullanici
{
    public int Id { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public string Email { get; set; } = null!;
}
