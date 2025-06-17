namespace CentroEventos.Aplicacion.CasosDeUsos.Listar;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class ListarPersonaUseCase(IRepositorioPersona repo)
{
    public List<Persona> Ejecutar(){
        return repo.ListarPersona();
    }
}