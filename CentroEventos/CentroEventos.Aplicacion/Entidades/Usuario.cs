namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }

    // No sé si esto estará bien. Pregunté por ideas
    public List<Permiso> UsuarioPermisos { get; set; } = new List<Permiso>();
}

