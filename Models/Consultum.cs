using System;
using System.Collections.Generic;

namespace MotoPuntoBack.Models;

public partial class Consultum
{
    public int Idconsulta { get; set; }

    public int? Idusuario { get; set; }

  

    public int? Idmoto { get; set; }

    public int? Estado { get; set; }

    public DateTime? Fecha { get; set; }


    public DateTime? FechaContacto { get; set; }

    public virtual Moto? IdmotoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
