using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class Kadromuz
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Unvan { get; set; } = null!;

    public string Yol { get; set; } = null!;

    public bool AktifMi { get; set; }
}
