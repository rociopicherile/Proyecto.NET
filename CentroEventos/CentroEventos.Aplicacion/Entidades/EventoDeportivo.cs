namespace CentroEventos.Aplicacion;

class EventoDeportivo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio{get; set;}
    public double DuracionHoras{get; set;}
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; } 

    public override string ToString(){
        return $"ID:{id}, PersonaId(id de la persona que concreto la reserva): {PersonaId}, EventoDeportivo(id del evento que se reservo):{EventoDeportivoId}, Fecha y Hora:{FechaAltaReserva}, Asistencia:{EstadoAsistencia}";
    }
}
