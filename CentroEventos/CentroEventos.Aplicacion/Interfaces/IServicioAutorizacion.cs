using System;

using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
   public bool PoseeElPermiso(int IdUsuario, Permiso permiso);
}