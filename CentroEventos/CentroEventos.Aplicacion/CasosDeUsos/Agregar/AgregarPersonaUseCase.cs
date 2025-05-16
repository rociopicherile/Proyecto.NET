
namespace CentroEventos.Aplicacion;


public class AgregarPersonaUseCase (IRepositorioPersona perso,PersonaValidador validador){

    public void Ejecutar(Persona persona){

        if (!validador.Validar(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }


        perso.AgregarPersona(persona);
    }

}

// falta agregar lo de repo de email y dni