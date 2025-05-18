namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio{get; set;}
    public double DuracionHoras{get; set;}
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; } 

   public override string ToString()
{
    return $"ID: {Id}, Nombre: {Nombre}, Descripción: {Descripcion}, " +
           $"Fecha y Hora de Inicio: {FechaHoraInicio}, Duración: {DuracionHoras} horas, " +
           $"Cupo Máximo: {CupoMaximo}, Responsable ID: {ResponsableId}";
}
}
