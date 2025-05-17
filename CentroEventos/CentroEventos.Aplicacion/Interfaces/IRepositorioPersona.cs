using CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void EliminarPersona(int id);
    List<Persona> ListarPersona();
    void ActualizarPersona(Persona persona);
    
    bool ExisteDNI(string dni);
    bool ExisteEmail(string email);
    bool ExisteId(int id);
    Persona BuscarPersona(int id);
}