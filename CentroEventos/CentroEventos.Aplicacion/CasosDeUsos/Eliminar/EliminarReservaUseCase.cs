// Corregido por Sebas
namespace CentroEventos.Aplicacion.Eliminar;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class EliminarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,int id){
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.ReservaeBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        //UNICAMENTE VERIFICO QUE LA RESERVA EXISTA
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta eliminar no existe");
        }
        repo.EliminarReserva(id);
    }
}