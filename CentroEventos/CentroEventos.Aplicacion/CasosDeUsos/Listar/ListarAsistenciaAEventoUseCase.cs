namespace CentroEventos.Aplicacion;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class ListarAsistenciaAEventoUseCase(IRepositorioReserva res, IRepositorioPersona per, IRepositorioEventoDeportivo eve)
{
    public List<Persona> Ejecutar() {

        var resultado = new List<Persona>();

        res.ListarReserva();
        foreach (Reserva reserva in res)
        {
            if (reserva.EstadoAsistencia == EstadoAsistencia.Asistio)// no se si esta bien
            {
                var evento = eve.BuscarEvento(reserva.EventoDeportivoId);
                if (evento.FechaHoraInicio < DateTime.Now)// no se si tengo q sumarle las horas de duracion y ersta bien escho
                {
                    var persona = per.BuscarPersona(reserva.PersonaId);
                    resultado.Add(persona);    
                }
            } 

        }
                
        return resultado;
    }

}