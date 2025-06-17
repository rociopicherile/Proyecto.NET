// Sebas



namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

using System;
using CentroEventos.Aplicacion;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Linq;

public class RepositorioReservaEF: IRepositorioReserva
{
    private readonly CentroEventosContext _dbContext;
    public RepositorioReservaEF(CentroEventosContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Reserva> ListarReserva()
    {
        return _dbContext.Reservas.ToList();
    }

    public void AgregarReserva(Reserva p)
    {
        _dbContext.Reservas.Add(p);
        _dbContext.SaveChanges();
    }


    public void ActualizarReserva(Reserva r)
    {
        var reser = BuscarReserva(r.Id);
        _dbContext.Entry(reser).CurrentValues.SetValues(r);
        _dbContext.SaveChanges();
    }

    public void EliminarReserva(int Id)
    {
        var reserva = BuscarReserva(Id);
        _dbContext.Reservas.Remove(reserva);
        _dbContext.SaveChanges();
    }

    public Reserva BuscarReserva(int r)
    {
        return _dbContext.Reservas.First( n => n.Id ==r);
    }
    public bool Reservo(int idP, int idE)
    {
        return _dbContext.Reservas.Any(n => n.PersonaId == idP && n.EventoDeportivoId == idE);
    }

    public int CantidadDeReservas(int id)
    {//devuelve la cantidad de personas que reservaron en un evento cuyo id se pasa por parametro
        return _dbContext.Reservas.Count(r => r.EventoDeportivoId == id);
    }

    public bool EventoTieneReservaAsociada(int Id)
    {
        return _dbContext.Reservas.Any(n => n.EventoDeportivoId == Id );
    }

    public bool PersonaTieneReservaAsociada(int Id)
    {
        return _dbContext.Reservas.Any(n => n.PersonaId == Id );
    
    }

    public bool ExisteId(int id)
    {
        return _dbContext.Reservas.Any(n => n.Id == id );
    }

}