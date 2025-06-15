using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioUsuario
{

    void AgregarUsuario(Usuario usuario);

    void EliminarUsuario(int id);

    List<Usuario> ListarUsuario();

    void ActualizarUsuario(Usuario usuario);

    bool ExisteEmail(string email);

}