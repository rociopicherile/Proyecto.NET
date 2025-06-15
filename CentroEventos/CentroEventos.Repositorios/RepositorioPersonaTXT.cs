/* 
No sé si está bien esto
*/

namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

using System;
using CentroEventos.Aplicacion;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class RepositorioPersonaEF : IRepositorioPersona
{
    private readonly CentroEventosContext _dbContext;

    public RepositorioPersonaEF(CentroEventosContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE
    public void AgregarPersona(Persona persona)
    {
        _dbContext.Personas.Add(persona);
        _dbContext.SaveChanges();
    }

    // DELETE
    public void EliminarPersona(int id)
    {
        var persona = BuscarPersona(id);
        _dbContext.Personas.Remove(persona);
        _dbContext.SaveChanges();
    }

    // READ
    public List<Persona> ListarPersona()
    {
        return _dbContext.Personas.ToList();
    }

    // UPDATE
    public void ActualizarPersona(Persona persona)
    {
        // (1) Busco a la persona con sus datos viejos
        Persona personaVieja = BuscarPersona(persona.Id);
        
        // (2) Copiar TODOS los valores del objeto nuevo al existente
        _dbContext.Entry(personaVieja).CurrentValues.SetValues(persona);

        // (3) Guardar cambios
        _dbContext.SaveChanges();
        
    }

    public bool ExisteDNI(string dni)
    {
        foreach (Persona p in this.ListarPersona())
        {
            if (p.DNI == dni)
            {
                return true;
            }
        }
        return false;
    }

    public bool ExisteEmail(string email)
    {
        foreach (Persona p in this.ListarPersona())
        {
            if (p.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public bool ExisteId(int id)
    {
        foreach (Persona p in this.ListarPersona())
        {
            if (p.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public Persona BuscarPersona(int id)
    {
        return this.ListarPersona().First(p => p.Id == id);
    }

}
