namespace CentroEventos.Aplicacion.Agregar;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class EliminarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list, int id)
    {
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.UsuarioBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("El Usuario que se intenta eliminar no está registrado.");
        }
        repo.EliminarUsuario(id);
    }
}