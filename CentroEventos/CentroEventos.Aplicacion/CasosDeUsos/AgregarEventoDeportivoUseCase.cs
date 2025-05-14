namespace CentroEventos.Aplicacion;

public class AgregarEventoDeportivoUseCase (IRepositorioEventoDeportivo Event, EventoDeportivoValidador validador){

    public void Ejecutar(EventoDeportivo eventoDeportivo){

        if(!validador.Validar(eventoDeportivom, out string mensajeError)){

            throw new Exception(mensajeError);
        }

        Event.AgregarEventoDeportivo(eventoDeportivo);
    }

}