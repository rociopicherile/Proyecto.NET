/* 
"No puede eliminarse un EventoDeportivo si existen Reservas asociadas al mismo
(independientemente del estado de las reservas)."

Corregido por mí (Rocío Belén)
*/
namespace CentroEventos.Aplicacion.CasosDeUsos.Eliminar;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list,int id){ 
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.EventoBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("El evento que se intenta elimnar no esta registrado.");
        }
        if(!validador.ValidarNoTieneReservaAsociada(id)){
            throw new OperacionInvalidaException("El evento que se intenta eliminar cuenta con al menos una reserva asociada.");
        }
        repo.EliminarEventoDeportivo(id);
    }
}
