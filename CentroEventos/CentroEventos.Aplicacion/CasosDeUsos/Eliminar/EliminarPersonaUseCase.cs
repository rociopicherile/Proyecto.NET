/*
"No puede eliminarse una Persona si es responsable de algún EventoDeportivo o si existen reservas
asociadas a ella (independientemente del estado de las reservas)."


terminado (creo)
*/

using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarPersonaUseCase(IRepositorioPersona repoP, PersonaValidador validador)
{
    public void Ejecutar(int id){ 
        if(!validador.ValidarExiste(id)){
            throw new EntidadNotFoundException("La persona que se intenta eliminar no está registrada.");
        }
        if(!validador.ValidarNoTieneReservaAsociada(id)){
            throw new OperacionInvalidaException("La persona que se intenta eliminar cuenta con al menos una reserva asociada.");
        }
        if(!validador.ValidarNoEsResponsableDeEventoDeportivo(id)){
            throw new OperacionInvalidaException("La persona que se intenta eliminar es responsable de al menos un evento deportivo.")
        }
        repoP.EliminarPersona(id);
    }
}
