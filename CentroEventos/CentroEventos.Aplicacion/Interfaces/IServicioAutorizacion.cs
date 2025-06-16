namespace CentroEventos.Aplicacion.Interfaces;

using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

public interface IServicioAutorizacion
{
   public bool PoseeElPermiso(List<EnumPermisos> list, EnumPermisos permiso);
}