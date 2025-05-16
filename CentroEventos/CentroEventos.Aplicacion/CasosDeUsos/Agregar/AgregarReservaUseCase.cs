namespace CentroEventos.Aplicacion;

public class AgregarReservaUseCase (IRepositorioReserva reser,ReservaValidador validador){

    public void Ejecutar(Reserva reserva){

        if (!validador.Validar(reserva, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }


        reser.AgregarReserva(reserva);
    }

}