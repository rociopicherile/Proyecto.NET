namespace CentroEventos.Aplicacion.Agregar;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class AgregarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int IdUsuario, Usuario u)
    {   
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioAlta))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }

        repo.AgregarUsuario(u);
    }
    
}