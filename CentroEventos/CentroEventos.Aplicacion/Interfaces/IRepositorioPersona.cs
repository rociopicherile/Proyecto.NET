public interface IRepositorioPersona{
    void AgregarPersona(Persona persona);
    void EliminarPersona(Persona persona);
    List<Persona> ListarPersona();
    void Actualizar(Persona persona);
    bool ExisteDNI(string dni);
    bool ExisteEmail(string email);
}