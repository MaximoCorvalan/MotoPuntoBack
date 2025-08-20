namespace MotoPuntoBack.DTOs
{
    public class ConsultaDTO
    {
        public int Idconsulta { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string? Fecha { get; set; }

        public string? FechaContacto { get; set; }


        public string NombreMoto { get; set; } = null!;
        public string Estado { get; set; } = null!;

    }


    public class ConsultaDTOPost 
    {
        public int Idconsulta { get; set; }

        public int? Idusuario { get; set; }



        public int? Idmoto { get; set; }

        public int? Estado { get; set; }

        public DateTime? Fecha { get; set; }


        public DateTime? FechaContacto { get; set; }

    }
}
