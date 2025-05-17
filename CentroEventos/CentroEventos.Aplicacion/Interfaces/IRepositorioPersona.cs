namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

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