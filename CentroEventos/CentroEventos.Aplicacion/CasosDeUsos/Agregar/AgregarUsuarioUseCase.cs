// Añadí lo de hashear la contraseña y asignarle todos los permisos si es el admin

namespace CentroEventos.Aplicacion.CasosDeUsos.Agregar;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Seguridad;


public class AgregarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(List<EnumPermisos> list, Usuario u)
    {
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.UsuarioAlta))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }

        if (!validador.ValidarNombre(u.Nombre))
        {
            throw new ValidacionException("No se ingresó el nombre del Usuario");
        }

        if (!validador.ValidarApellido(u.Apellido))
        {
            throw new ValidacionException("No se ingresó el apellido del Usuario");
        }

        if (!validador.ValidarEmail(u.Email))
        {
            throw new ValidacionException("No se ingresó el Email del Usuario");
        }
        if (!validador.ValidarContraseña(u.Contraseña))
        {
            throw new ValidacionException("No se ingresó la Contraseña del Usuario");
        }
        if (validador.ValidarExisteEmail(u.Email))
        {
            throw new DuplicadoException("Ya existe un Usuario registrado con el Email ingresado.");
        }

        // Hashear contraseña
        u.Contraseña = ContraseñaHash.Hash(u.Contraseña);

        // Si es el primer usuario en registrarse (admin), le otorgo todos los permisos

        if (!repo.ExistenUsuariosRegistrados())
        { 
            u.UsuarioPermisos = Enum.GetValues(typeof(EnumPermisos)).Cast<EnumPermisos>().ToList();
        }
        repo.AgregarUsuario(u);
    }

}