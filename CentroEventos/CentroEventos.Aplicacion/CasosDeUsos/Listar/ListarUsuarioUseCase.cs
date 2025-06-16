namespace CentroEventos.Aplicacion;


using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

public class ListarUsuarioUseCase(IRepositorioUsuario repo)
{
    public List<Usuario> Ejecutar()
    {
        return repo.ListarUsuario();
    }
}
