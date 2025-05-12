namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
public class RepositorioReservaTXT /* : IRepositorioReserva */ {
    readonly string _nombreArch = "reservas.txt";
   
    public void Agregar(Reserva reserva){
        // Completar: reserva.Id = GenerarNuevoId();
        using var sw = new StreamWriter(_nombreArch, true);

        // Crear una lista de los campos comunes
        var campos = new List<string>
        {
            "ID: "+reserva.Id.ToString(),
            "Persona ID: "+reserva.PersonaId.ToString(),
            "Actividad deportiva ID: "+reserva.EventoDeportivoId.ToString(),
            reserva.FechaAltaReserva.ToString(),
            reserva.EstadoAsistencia.ToString()
        };

        // Escribir la línea al archivo, separada por coma
        sw.WriteLine(string.Join(" - ", campos));
    }
}