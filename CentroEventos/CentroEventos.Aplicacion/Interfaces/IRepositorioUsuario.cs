using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioUsuario
{

    void AgregarUsuario(Usuario usuario);

    void EliminarUsuario(int id);

    List<Usuario> ListarUsuario();

    void ActualizarUsuario(Usuario usuario);

    Usuario BuscarUsuario(int id);

    Boolean ExistenUsuariosRegistrados();
   
    bool BuscarUsuarioPorEmail(string email);

    /*
    bool ExisteId(int id);
    */
}