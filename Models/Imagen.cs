using System;
using System.Collections.Generic;

namespace MotoPuntoBack.Models;

public partial class Imagen
{
    public int Idmfoto { get; set; }

    public int? Idmoto { get; set; }

    public string? Urlimagen { get; set; }

    public int? Principal { get; set; }

    public virtual Moto? IdmotoNavigation { get; set; }
}
