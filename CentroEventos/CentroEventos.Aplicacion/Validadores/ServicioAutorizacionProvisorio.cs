public class ServicioAutorizacionProvisorio:IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario,Permisos p){
        
        return IdUsuario == 1;
    }
}
