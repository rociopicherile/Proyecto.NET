/* 
"No puede eliminarse un EventoDeportivo si existen Reservas asociadas al mismo
(independientemente del estado de las reservas)."

Supongo que hay que recorrer al archivo de Reservas verificando si existe el evento deportivo

Comentario: No sé si está bien esto que hice. Preguntar en la práctica

*/

using System;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarEventoDeportivoUseCase (IRepositorioEventoDeportivo repoED, IRepositorioReserva repoR){

    public void Ejecutar(int Id){
        // Si existe el evento deportivo y no tiene ninguna reserva asociada
        if (repoED.ExisteId(Id) && !repoR.ExisteEventoDeportivoAsociado(Id)){
            repoED.EliminarEventoDeportivo(id);
        }
        else{
            throw new OperacionInvalidaException("No es posible eliminar al evento pues tiene al menos una reserva que se le corresponde");
        }
    }
}