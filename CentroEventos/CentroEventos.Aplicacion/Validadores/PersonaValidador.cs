namespace CentroEventos.Aplicacion;

public class PersonaValidador {

    public bool Validar(Persona persona, IRepositorioPersona repositorio,out string mensajeError){

        mensajeError = "";
        if(string.IsNullOrWhiteSpace(persona.Nombre)){

            mensajeError += "Nombre del persona inválido.\n";
        }

        if(string.IsNullOrWhiteSpace(persona.Apellido)){

            mensajeError += "Apellido del persona inválido.\n";
        }

        if(string.IsNullOrWhiteSpace(persona.DNI)){

            mensajeError += "DNI del persona inválido.\n";
        }
        else if (repositorio.ExisteDNI){
            mensajeError += "El DNI ya está registrado en otra persona.\n";
        }

        if(string.IsNullOrWhiteSpace(persona.Email)){

            mensajeError += "Email del persona inválido.\n";
        }
        else if (repositorio.ExisteEmail){
            
            mensajeError += "El email ya está registrado en otra persona.\n";
        }

        return (mensajeError == "");
    }
}