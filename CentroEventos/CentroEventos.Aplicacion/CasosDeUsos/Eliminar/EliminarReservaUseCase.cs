/*
Creo que en este caso no hay que verificar nada antes de eliminar
*/

using System;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarReservaUseCase (IRepositorioReserva repoR){


    public void Ejecutar(int Id){
        repoR.EliminarReserva(Id);
    }
}