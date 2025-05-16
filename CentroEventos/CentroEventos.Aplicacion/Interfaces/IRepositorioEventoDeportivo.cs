using CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo ed);
    void EliminarEventoDeportivo(int id);
    List<EventoDeportivo> ListarEventoDeportivo();
    void ActualizarEventoDeportivo(EventoDeportivo ed);

    EventoDeportivo BuscarEvento(int id);
    // Completar
}