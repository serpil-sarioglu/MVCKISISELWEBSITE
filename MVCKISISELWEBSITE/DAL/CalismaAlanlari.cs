using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class CalismaAlanlari
{
    public int Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public bool AktifMi { get; set; }

    public int Sira { get; set; }
}
