// Código corregido por Sebas
namespace CentroEventos.Aplicacion;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;



public class ActualizarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,Persona p){
        if (!autorizacion.PoseeElPermiso(IdUsuario, permiso))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(p.Id))
        {
            throw new EntidadNotFoundException("La persona que  se intenta actualizar no existe.");
        }
        repo.ActualizarPersona(p);
    }
}


