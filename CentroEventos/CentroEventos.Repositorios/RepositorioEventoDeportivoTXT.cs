// Hecho por Sebas: Agregar y Listar
// Hecho por Mati: Actualizar y ID Único
// Falta: EliminarEventoDeportivo, etc
// hecho por german : agregar el using y el namespace y metodo de buscar un evento 
namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArchivo = "eventoDeportivo.txt";
    readonly string _archivoIds = "IDsEventosDeportivos.txt";
    private int _idUltimo;

    public RepositorioEventoDeportivoTxT()
    {
        using var sr = new StreamReader(_archivoIds);
        _idUltimo = int.Parse(sr.ReadToEnd());
    }

    public List<EventoDeportivo> ListarEventoDeportivo()
    {
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var e = new EventoDeportivo();
            e.Id = int.Parse(sr.ReadLine() ?? "");
            e.Nombre = sr.ReadLine() ?? "";
            e.Descripcion = sr.ReadLine() ?? "";
            e.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            e.DuracionHoras = double.Parse(sr.ReadLine() ?? "");
            e.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            e.Responsableld = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(e);
        }
        return resultado;
    }

    public void AgregarEventoDeportivo(EventoDeportivo ed)
    {
        _idUltimo++;
        using var sw2 = new StreamWriter(_archivoIds, false);

        using var sw = new StreamWriter(_nombreArchivo, true);
        ed.id = _idUltimo;
        sw.WriteLine(ed.Id);
        sw.WriteLine(ed.Nombre);
        sw.WriteLine(ed.Descripcion);
        sw.WriteLine(ed.FechaHoraInicio);
        sw.WriteLine(ed.DuracionHoras);
        sw.WriteLine(ed.CupoMaximo);
        sw.WriteLine(ed.ResponsableId);
        sw2.WriteLine(_idUltimo);
    }

    public void ActualizarEventoDeportivo(EventoDeportivo ed)
    {
        Boolean encontrado = false;
        using var sr = new StreamReader(_nombreArchivo);
        using var sw = new StreamWriter("archivoTemporal.TXT");
        EventoDeportivo temp = new EventoDeportivo();
        while (!sr.EndOfStream)
        {
            temp.Id = int.Parse(sr.ReadLine() ?? "");
            temp.Nombre = sr.ReadLine() ?? "";
            temp.Descripcion = sr.ReadLine() ?? "";
            temp.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            temp.DuracionHoras = int.Parse(sr.ReadLine() ?? "");
            temp.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            temp.ResponsableId = int.Parse(sr.ReadLine() ?? "");
            if (temp.Id == ed.Id)
            {
                sw.WriteLine(ed.Id);
                sw.WriteLine(ed.Nombre);
                sw.WriteLine(ed.Descripcion);
                sw.WriteLine(ed.FechaHoraInicio);
                sw.WriteLine(ed.DuracionHoras);
                sw.WriteLine(ed.CupoMaximo);
                sw.WriteLine(temp.ResponsableId);
                encontrado = true;
            }
            else
            {
                sw.WriteLine(temp.Id);
                sw.WriteLine(temp.Nombre);
                sw.WriteLine(temp.Descripcion);
                sw.WriteLine(temp.FechaHoraInicio);
                sw.WriteLine(temp.DuracionHoras);
                sw.WriteLine(temp.CupoMaximo);
                sw.WriteLine(temp.ResponsableId);
            }
        }
        if (!encontrado)
        {
            File.Delete("archivoTemporal.TXT");
            Console.WriteLine("Evento no encontrado");
        }
        else
        {
            File.Delete(_nombreArchivo);
            File.Move("archivoTemporal.TXT", _nombreArchivo);
        }
    }

    public EventoDeportivo BuscarEvento(int id)// no se si esta bien
    {
        var eventoDeportivo = this.ListarEventoDeportivo();
        int i = 0;

        while (i < eventoDeportivo.Count)
        {
            if (eventoDeportivo[i].Id == id)
            {
                return eventoDeportivo[i];
            }
            i++;
        }
    }

    public bool ExisteId(int id)
    {
        foreach (EventoDeportivo ed in this.ListarEventoDeportivo())
        {
            if (ed.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    /*public bool EsResponsableDeEventoDeportivo (int id){
        List <EventoDeportivo> listaEventos = ListarEventoDeportivo();
    }*/

}