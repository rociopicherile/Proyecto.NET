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
using System.Data.Common;

public class RepositorioEventoDeportivoEF : IRepositorioEventoDeportivo
{
   private readonly CentroEventosContext _dbContext;
    public RepositorioEventoDeportivoEF(CentroEventosContext dbContext)
    {
        _dbContext = dbContext;
    }

    //CREATE

    public void AgregarEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        _dbContext.EventosDeportivos.Add(eventoDeportivo);
        _dbContext.SaveChanges();
    }

    public void EliminarEventoDeportivo(int id)
    {
        var evento = BuscarEvento(id);
        _dbContext.EventosDeportivos.Remove(evento);
        _dbContext.SaveChanges();
    }

    //READ

    public List<EventoDeportivo> ListarEventoDeportivo()
    {
        return _dbContext.EventosDeportivos.ToList();
    }

    public void ActualizarEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        EventoDeportivo evento_old = BuscarEvento(eventoDeportivo.Id);
        _dbContext.Entry(evento_old).CurrentValues.SetValues(eventoDeportivo);
        _dbContext.SaveChanges();
    }
    
    

       public EventoDeportivo BuscarEvento(int id)
    {
        return this.ListarEventoDeportivo().First(e => e.Id == id);
    }

    public bool ExisteId(int id)
    {
        foreach (EventoDeportivo ed in this.ListarEventoDeportivo())
        {
            if (ed.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public bool EsResponsableDeEventoDeportivo(int Id)
    {
        List<EventoDeportivo> listaEventos = ListarEventoDeportivo();

        int i = 0;
        bool encontre = false;

        //Recorro a la list de eventos deportivos, buscando si exista alguno que tenga el mismo ResponsableId
        while (i < listaEventos.Count && !encontre)
        {
            if (listaEventos[i].ResponsableId == Id)
            {
                encontre = true;
            }
            i++;
        }

        return encontre;
    }

    public int DevolverCupoMaximo(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return e.CupoMaximo;
            }
        }
        return 0;
    }

    public bool Expiro(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return e.FechaHoraInicio < DateTime.Now;
            }
        }
        return false;
    }

}