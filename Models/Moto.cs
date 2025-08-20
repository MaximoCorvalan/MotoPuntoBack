using System;
using System.Collections.Generic;

namespace MotoPuntoBack.Models;

public partial class Moto
{
    public int Idmoto { get; set; }

    public string Nombre { get; set; } = null!;

    public int Idmarca { get; set; }

    public double Cilindrada { get; set; }

    public string Motor { get; set; } = null!;

    public string? Potencia { get; set; }

    public string? Suspenciond { get; set; }

    public string? Suspenciont { get; set; }

    public string? Alimentacion { get; set; }

    public string? Encendido { get; set; }

    public string? Iluminacion { get; set; }

    public double Tanquel { get; set; }

    public string? Transmision { get; set; }

    public string Cajacambio { get; set; } = null!;

    public double Precio { get; set; }

    public string Tipomoto { get; set; } = null!;

    public string? Neumaticot { get; set; }

    public string? Neumaticod { get; set; }

    public string? Refrigeracion { get; set; }

    public string? Combustible { get; set; }

    public string? Aceite { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Marca IdmarcaNavigation { get; set; } = null!;

    public virtual ICollection<Imagen> Imagens { get; set; } = new List<Imagen>();
}
