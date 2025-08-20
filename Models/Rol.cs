using System;
using System.Collections.Generic;

namespace MotoPuntoBack.Models;

public partial class Rol
{
    public int Idrol { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
