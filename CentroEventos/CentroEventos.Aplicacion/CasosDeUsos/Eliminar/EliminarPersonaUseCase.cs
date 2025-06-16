/*
"No puede eliminarse una Persona si es responsable de algún EventoDeportivo o si existen reservas
asociadas a ella (independientemente del estado de las reservas)."


terminado (creo)
*/
namespace CentroEventos.Aplicacion.Eliminar;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class EliminarPersonaUseCase(IRepositorioPersona repoP, PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list,int id){
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.UsuarioBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        } 
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("La persona que se intenta eliminar no está registrada.");
        }
        if(!validador.ValidarNoTieneReservaAsociada(id)){
            throw new OperacionInvalidaException("La persona que se intenta eliminar cuenta con al menos una reserva asociada.");
        }
        if(!validador.ValidarNoEsResponsableDeEventoDeportivo(id)){
            throw new OperacionInvalidaException("La persona que se intenta eliminar es responsable de al menos un evento deportivo.");
        }
        repoP.EliminarPersona(id);
    }
}
