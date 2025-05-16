/*
"No puede eliminarse una Persona si es responsable de algún EventoDeportivo o si existen reservas
asociadas a ella (independientemente del estado de las reservas)."

Supongo que antes de eliminar a la persona habría que verificar en los archivos de EventoDeportivo  y
de Reservas si existe un ID que coincida


Comentario: No sé si está bien esto que hice. Preguntar en la práctica
*/

using System;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarPersonaUseCase (IRepositorioPersona repoP, IRepositorioEventoDeportivo repoED, IRepositorioReserva repoR){
    public void Ejecutar(int Id){
        // (1) Obtengo las listas de Reservas y Eventos Deportivos
        List <Reserva> listaReservas = repoR.ListarReserva();
        List <EventoDeportivo> listaEventos = repoED.ListarEventoDeportivo();

        bool sePuedeBorrar = true;
        int i = 0;
        // (2) Recorro ambas listas verificando si a mi persona se le corresponde un evento/reserva
        while (i < listaReservas.Count && sePuedeBorrar)
        {
            if (listaReservas[i].PersonaId == Id)
            {
                sePuedeBorrar = false;
            }
            i++;
        }
        // (4) Si en la lista de Reservas no encontré ninguna persona, busco en la lista de Eventos
        i = 0;
        while (i < listaEventos.Count && sePuedeBorrar)
        {
            if (listaEventos[i].ResponsableId == Id)
            {
                sePuedeBorrar = false;
            }
            i++;
        }
        
        // (5) Si en ninguna lista encontré a la persona, la borro sin problemas
        if (sePuedeBorrar){
            repoP.EliminarPersona(Id);
        }
        else{ // (6) Si no, lanzo una excepción
            throw new OperacionInvalidaException("No es posible eliminar a la persona porque se le corresponde un Evento Deportivo o una Reserva. ");
        }
    }

}