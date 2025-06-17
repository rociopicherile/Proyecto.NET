// Código corregido por Sebas
namespace CentroEventos.Aplicacion.CasosDeUsos.Actualizar;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;



public class ActualizarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list,Persona p){
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(p.Id))
        {
            throw new EntidadNotFoundException("La persona que  se intenta actualizar no existe.");
        }
        repo.ActualizarPersona(p);
    }
}


