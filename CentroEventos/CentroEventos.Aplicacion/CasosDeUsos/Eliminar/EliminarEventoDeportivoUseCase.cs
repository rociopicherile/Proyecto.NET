/* 
"No puede eliminarse un EventoDeportivo si existen Reservas asociadas al mismo
(independientemente del estado de las reservas)."

Corregido por mí (Rocío Belén)
*/

using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador)
{
    public void Ejecutar(int id){ 
        if(!validador.ValidarExiste(id)){
            throw new EntidadNotFoundException("El evento que se intenta elimnar no esta registrado.");
        }
        if(!validador.ValidarNoTieneReservaAsociada(id)){
            throw new OperacionInvalidaException("El evento que se intenta eliminar cuenta con al menos una reserva asociada.");
        }
        repo.EliminarEventoDeportivo(id);
    }
}
