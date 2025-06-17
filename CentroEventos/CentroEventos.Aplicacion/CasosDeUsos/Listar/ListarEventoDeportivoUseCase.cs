namespace CentroEventos.Aplicacion.CasosDeUsos.Listar;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;


public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public List<EventoDeportivo> Ejecutar(){
        return repo.ListarEventoDeportivo();
    }
}
