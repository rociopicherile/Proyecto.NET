namespace CentroEventos.Aplicacion;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class ActualizarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list, Usuario u)
    {
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(u.Id))
        {
            throw new EntidadNotFoundException("El usuario que  se intenta actualizar no existe.");
        }
        repo.ActualizarUsuario(u);
    }
}