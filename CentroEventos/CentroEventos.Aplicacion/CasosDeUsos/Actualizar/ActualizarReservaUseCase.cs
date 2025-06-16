// Código corregido por Sebas
namespace CentroEventos.Aplicacion;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;



public class ActualizarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(List<EnumPermisos> list,Reserva r){
        if (!autorizacion.PoseeElPermiso(list, EnumPermisos.ReservaModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(r.Id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta actualizar no existe");
        }
        repo.ActualizarReserva(r);
    }
}