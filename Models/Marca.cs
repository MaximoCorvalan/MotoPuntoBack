using System;
using System.Collections.Generic;

namespace MotoPuntoBack.Models;

public partial class Marca
{
    public int Idmarca { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Moto> Motos { get; set; } = new List<Moto>();
}
