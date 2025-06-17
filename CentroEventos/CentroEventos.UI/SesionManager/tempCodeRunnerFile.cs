using CentroEventos.Aplicacion.Entidades;

public class UsuarioSesion
{
    // Guarda sólo lo necesario: Id y Permisos; si necesitas más, añade propiedades.
    public int        IdUsuario   { get; private set; }
    public List<EnumPermisos> Permisos { get; private set; }

    public bool EstaLogueado => IdUsuario != 0;

    public void SetUsuario(Usuario u)
    {
        IdUsuario = u.Id;
        Permisos = u.UsuarioPermisos;
    }

    public void Logout()
    {
        IdUsuario = 0;
        Permisos  = Permisos.Clear();
    }

    public bool TienePermiso(Permiso p) => Permisos.Contains(p);
}