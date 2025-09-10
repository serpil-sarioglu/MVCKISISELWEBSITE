using System;
using System.Collections.Generic;

namespace MVCKISISELWEBSITE.DAL;

public partial class Slider
{
    public int Id { get; set; }

    public string Yol { get; set; } = null!;

    public int Sira { get; set; }

    public bool AktifMi { get; set; }
}
