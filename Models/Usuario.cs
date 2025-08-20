using System;
using System.Collections.Generic;

namespace MotoPuntoBack.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public int Idrol { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int Estado { get; set; }

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Rol IdrolNavigation { get; set; } = null!;
}
