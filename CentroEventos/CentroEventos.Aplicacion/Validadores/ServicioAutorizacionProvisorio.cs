namespace CentroEventos.Aplicacion.Validadores;


using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;



public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(List<EnumPermisos> list, EnumPermisos p)
    {
        return list.Contains(p);
    }
}
