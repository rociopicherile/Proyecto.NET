
namespace CentroEventos.Aplicacion.Interfaces;
using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public interface IRepositorioReserva
{
    public List<Reserva> ListarReserva();
    public void AgregarReserva(Reserva r);
    public void EliminarReserva(int id);
    public void ActualizarReserva(Reserva r);

    public bool PersonaTieneReservaAsociada(int id);
    public bool EventoTieneReservaAsociada(int id);
    public bool ExisteId(int id);
    bool Reservo(int idP, int idE);
    public int CantidadDeReservas(int id);//devuelve la cantidad de personas que reservaron en un evento cuyo id se pasa por parametro
}