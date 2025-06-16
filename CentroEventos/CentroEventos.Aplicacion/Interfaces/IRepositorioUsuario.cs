using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioUsuario
{

    void AgregarUsuario(Usuario usuario);

    void EliminarUsuario(int id);

    List<Usuario> ListarUsuario();

    void ActualizarUsuario(Usuario usuario);

    Usuario BuscarUsuario(int id);

    /*
    bool ExisteEmail(string email);
    bool ExisteId(int id);
    */
}