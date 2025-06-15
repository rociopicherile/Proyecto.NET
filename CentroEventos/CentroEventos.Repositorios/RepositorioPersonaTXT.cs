/* 
En proceso
*/

namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

using System;
using CentroEventos.Aplicacion;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class RepositorioPersonaTXT : IRepositorioPersona
{
    public void AgregarPersona(Persona persona)
    {
        
    }

    public void EliminarPersona(int id)
    {
        
    }

    
    public List<Persona> ListarPersona()
    {
        return null;
    }

    public void ActualizarPersona(Persona persona)
    {

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
