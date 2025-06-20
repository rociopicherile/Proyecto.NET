// Código corregido por Sebas
namespace CentroEventos.Aplicacion.CasosDeUsos.Agregar;


using System;
using System.Linq.Expressions;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class AgregarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list,Reserva r){
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.ReservaAlta))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarEventoDeportivoReservado(r.EventoDeportivoId))
        {
            throw new EntidadNotFoundException("El evento deportivo al que se quiere reservar no existe.");
        }
        if (!validador.ValidarPersonaQueRervo(r.PersonaId))
        {
            throw new EntidadNotFoundException("La Persona a la cual se le quiere asignar la reserva no existe.");
        }
        if (validador.ValidarSiYaReservo(r.PersonaId,r.EventoDeportivoId))
        {
            throw new DuplicadoException("Ya hay una reserva existente para dicha persona en dicho evento.");
        }
        if (!validador.ValidarSiHayCupo(r.EventoDeportivoId))
        {
            throw new ValidacionException("No quedan mas cupos para el evento ingresado.");
        }
        repo.AgregarReserva(r);
    }
}