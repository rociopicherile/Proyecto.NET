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

        if (!validador.ValidarNombre(u.Nombre))
        {
            throw new ValidacionException("No se ingreso el nombre de la Usuario");
        }

        if (!validador.ValidarApellido(u.Apellido))
        {
            throw new ValidacionException("No se ingreso el apellido de la Usuario");
        }

        if (!validador.ValidarEmail(u.Email))
        {
            throw new ValidacionException("No se ingreso el Email de la Usuario");
        }
        if (!validador.ValidarContraseña(u.Contraseña))
        {
            throw new ValidacionException("No se ingreso el Contraseña de la Usuario");
        }
        if (validador.ValidarExisteEmail(u.Email))
        {
            throw new DuplicadoException("Ya existe un Usuario registrada con el Email ingresado.");
        }

        repo.AgregarUsuario(u);
    }
    
}