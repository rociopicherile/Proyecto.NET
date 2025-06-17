// Belén


namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

public class RepositorioUsuarioEF : IRepositorioUsuario
{

    private readonly CentroEventosContext _dbContext;

    public RepositorioUsuarioEF(CentroEventosContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE
    public void AgregarUsuario(Usuario usuario)
    {
        _dbContext.Usuarios.Add(usuario);
        _dbContext.SaveChanges();
    }

    // DELETE 
    public void EliminarUsuario(int id)
    {
        var usuario = BuscarUsuario(id);
        _dbContext.Usuarios.Remove(usuario);
        _dbContext.SaveChanges();

    }
    public Usuario BuscarUsuario(int id)
    {
        return this.ListarUsuario().First(u => u.Id == id);
    }

    // READ
    public List<Usuario> ListarUsuario()
    {
        return _dbContext.Usuarios.ToList();
    }

    // UPDATE
    public void ActualizarUsuario(Usuario usuario)
    {
        // (1) Busco a la persona con sus datos viejos
        Usuario usuarioViejo = BuscarUsuario(usuario.Id);

        // (2) Copiar TODOS los valores del objeto nuevo al existente
        _dbContext.Entry(usuarioViejo).CurrentValues.SetValues(usuario);

        // (3) Guardar cambios
        _dbContext.SaveChanges();
    }

    public bool ExistenUsuariosRegistrados()
    { 
        return _dbContext.Usuarios.Any();
    }

    /*
    public bool ExisteEmail(string email) { }

    public bool ExisteId(int id) { }
    */
}