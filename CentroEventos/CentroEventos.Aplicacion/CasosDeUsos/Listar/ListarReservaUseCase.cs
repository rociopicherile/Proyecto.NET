namespace CentroEventos.Aplicacion.CasosDeUsos.Listar;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public class ListarReservaUseCase(IRepositorioReserva repo)
{
    public List<Reserva> Ejecutar(){
        return repo.ListarReserva();
    }
}