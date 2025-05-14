using CentroEventos.Aplicacion;

public interface IRepositorioReserva{
    void AgregarReserva(Reserva reserva);
    void EliminarReserva(int id);
    void ActualizarReserva(Reserva reserva);
    List<Reserva> ListarReserva();

    // Completar
}