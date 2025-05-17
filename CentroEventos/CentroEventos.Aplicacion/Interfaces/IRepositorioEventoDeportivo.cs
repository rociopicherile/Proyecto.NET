namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo ed);
    void EliminarEventoDeportivo(int id);
    List<EventoDeportivo> ListarEventoDeportivo();
    void ActualizarEventoDeportivo(EventoDeportivo ed);


    public bool ExisteId(int id);
    public int DevolverCupoMaximo(int id);
    public bool Expiro(int id);
    EventoDeportivo BuscarEvento(int id);
    public bool EsResponsableDeEventoDeportivo(int id);
}