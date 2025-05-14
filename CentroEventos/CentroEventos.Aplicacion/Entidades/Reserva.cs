
namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public EstadoAsistencia EstadoAsistencia { get; set; }

    public override string ToString(){
        return $"ID:{id}, PersonaId(id de la persona que concreto la reserva): {PersonaId}, EventoDeportivo(id del evento que se reservo):{EventoDeportivoId}, Fecha y Hora:{FechaAltaReserva}, Asistencia:{EstadoAsistencia}";
    }
}