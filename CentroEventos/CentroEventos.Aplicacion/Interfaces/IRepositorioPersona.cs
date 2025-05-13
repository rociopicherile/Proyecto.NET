public interface IRepositorioPersona{
    void AgregarPersona(Persona persona);

    bool ExisteDNI(string dni);
    bool ExisteEmail(string email);
}