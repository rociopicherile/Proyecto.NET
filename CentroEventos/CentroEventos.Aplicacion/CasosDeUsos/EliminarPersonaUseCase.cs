/*
"No puede eliminarse una Persona si es responsable de algún EventoDeportivo o si existen reservas
asociadas a ella (independientemente del estado de las reservas)."
*/

namespace CentroEventos.Aplicacion;

public class EliminarPersonaUseCase (IRepositorioPersona repoP, IRepositorioEventoEventoDeportivo repoED, IRepositorioReserva repoR){


    public void Ejecutar(Persona persona){
        // Completar. No sé bien cómo hacerlo
    }

}