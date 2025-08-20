namespace MotoPuntoBack.DTOs
{
    public class UsuarioDTO
    {
        public int Idrol { get; set; }
        public int Idusuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Email { get; set; } = null!;
        // Por seguridad, usualmente no mandamos la contraseña en un DTO público
        public string Contrasena { get; set; } = null!;

        public string? Direccion { get; set; }
        public int Estado { get; set; } 

      
    }
}
