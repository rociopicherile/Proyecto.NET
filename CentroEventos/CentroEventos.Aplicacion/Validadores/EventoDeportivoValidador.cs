// Esto lo hizo Sebas

public class EventoDeportivoValidador(IRepositorioPersona repo)
{
    public bool Validar(EventoDeportivo evento, out string mensaje){
        mensaje="";
        if(string.IsNullOrWhiteSpace(evento.Nombre)){
            mensaje+="ERROR. No se puede ingresar un nombre vacio.\n";
        }
        if(string.IsNullOrWhiteSpace(evento.Descripcion)){
            mensaje+="ERROR. No se puede ingresar una descripcion vacia.\n";
        }
        if(evento.FechaHoraInicio<DateTime.Now){
            mensaje+="ERROR. La fecha tiene que ser actual o posterior.\n";
        }
        if(evento.DuracionHoras<=0){
            mensaje+="ERROR. La duracion debe ser mayor a cero.\n";
        }
        if (evento.CupoMaximo<= 0){
            mensaje += "ERROR. El cupo máximo debe ser mayor a cero.\n"
        }
        if(!repo.ExisteId(evento.Responsableld)){
            mensaje+="ERROR. El responsable no corresponde a una persona existenete.\n";
        }
        return (mensaje=="");
    }
}