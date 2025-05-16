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
        // (1) Obtengo la lista de reservas
        List<Reserva> listaReservas = repoR.ListarReserva();
        int i = 0;
        bool sePuedeBorrar = true;

        //(2) Recorro a la list de reservas, buscando si exista alguna que tenga el mismo EventoDeportivoId
        while (i < listaReservas.Count && sePuedeBorrar){
            if (listaReservas[i].EventoDeportivoId == Id){
                sePuedeBorrar = false;
            }
            i++;
        }

        // (3) Verifico si se puede borrar o no
        if (sePuedeBorrar){
            repoED.EliminarEventoDeportivo(id);
        }
        else{
            throw new OperacionInvalidaException("No es posible eliminar al evento pues tiene al menos una reserva que se le corresponde");
        }
    }
}