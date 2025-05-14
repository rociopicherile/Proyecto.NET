// Hecho por Mati: Agregar(), Id y Actualizar()
// Falta: Eliminar y Listar

namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
public class RepositorioReservaTXT /* : IRepositorioReserva */ {
    readonly string _nombreArch = "reservas.txt";
    readonly string _archivoIds = "IDsReservas.txt";
    private int _idUltimo;
    public RepositorioReservaTxT (){
        using var sr= new StreamReader (_archivoIds);
        _idUltimo= int.Parse(sr.ReadToEnd());
    }
    public void AgregarReserva(Reserva r){
        reserva.Id = _idUltimo;
        _idUltimo++;
        using var sw2 = new StreamWriter(_archivoIds, false);
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
        sw2.WriteLine(_idUltimo);
    }

    public void ActualizarReserva(Reserva r){
        Boolean encontrado = false;
        using var sr = new StreamReader(_nombreArchivo);
        using var sw = new StreamWriter ("archivoTemporal.TXT");
        Reserva temp = new Reserva();
        while (!sr.EndOfStream){
            temp.IdReserva = int.Parse(sr.ReadLine()??"");
            temp.PersonaID = int.Parse(sr.ReadLine()??"");
            temp.EventoDeportivoID =int.Parse(sr.ReadLine()??"");
            temp.FechaAlta = DateTime.Parse(sr.ReadLine()??"");
            temp.EstadoAsistencia =Enum.Parse<EstadoAsistencia>(sr.ReadLine ()??"");

            if (temp.IdReserva ==r.IdReserva){
                sw.WriteLine (r.IdReserva);
                sw.WriteLine(r.PersonaID);
                sw.WriteLine(r.EventoDeportivoID);
                sw.WriteLine(r.FechaAlta);
                sw.WriteLine(r.EstadoAsistencia);
                encontrado = true;
            }
            else{
                sw.WriteLine (temp.IdReserva);
                sw.WriteLine(temp.PersonaID);
                sw.WriteLine(temp.EventoDeportivoID);
                sw.WriteLine(temp.FechaAlta);
                sw.WriteLine(temp.EstadoAsistencia);
            }
        }
        if (!encontrado ){
            File.Delete("archivoTemporal.TXT");
            Console.WriteLine("Evento no encontrado");
        }
        else{
            File.Delete (_nombreArchivo);
            File.Move("archivoTemporal.TXT", _nombreArchivo);
        }
     }
}