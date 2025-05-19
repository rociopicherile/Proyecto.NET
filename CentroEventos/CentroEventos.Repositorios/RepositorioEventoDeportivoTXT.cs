// Hecho por Sebas: Agregar y Listar
// Hecho por Mati: Actualizar y ID Único
// hecho por german : agregar el using y el namespace y metodo de buscar un evento 

// Terminado CREO

namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

using System;
using CentroEventos.Aplicacion;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArchivo = "eventoDeportivo.txt";
    readonly string _archivoIds = "IDsEventosDeportivos.txt";
    private int _idUltimo;

    public RepositorioEventoDeportivoTXT()
    {
        using var sw = new StreamWriter(_archivoIds);
        sw.WriteLine("0");
    }

    public List<EventoDeportivo> ListarEventoDeportivo()
    {//MODIFICADO POR LA BAJA LOGICA
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {// mientras no termine el archivo.
            var e = new EventoDeportivo();//creo un eventoDeportivo para ir agregando sus campos.
            string IdLinea = sr.ReadLine() ?? "";// leo una linea en una variable string.
            if (IdLinea.StartsWith("*"))
            {//aca verifico que no empiece por "*", osea que no tenga borrado logico.
                for (int i = 0; i < 6; i++)
                {
                    sr.ReadLine();//si tiene borrado logico, lo salto leyendo las demas lineas.
                }
            }
            else
            {// si no leo las linea y las agrego a la lista.
                e.Id = int.Parse(IdLinea);
                e.Nombre = sr.ReadLine() ?? "";
                e.Descripcion = sr.ReadLine() ?? "";
                e.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
                e.DuracionHoras = double.Parse(sr.ReadLine() ?? "");
                e.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
                e.ResponsableId = int.Parse(sr.ReadLine() ?? "");
                resultado.Add(e);
            }
        }
        return resultado;
    }

    public void AgregarEventoDeportivo(EventoDeportivo ed)
    {
        _idUltimo++;
        using var sw2 = new StreamWriter(_archivoIds, false);

        using var sw = new StreamWriter(_nombreArchivo, true);
        ed.Id = _idUltimo;
        sw.WriteLine(ed.Id);
        sw.WriteLine(ed.Nombre);
        sw.WriteLine(ed.Descripcion);
        sw.WriteLine(ed.FechaHoraInicio);
        sw.WriteLine(ed.DuracionHoras);
        sw.WriteLine(ed.CupoMaximo);
        sw.WriteLine(ed.ResponsableId);
        sw2.WriteLine(_idUltimo);
    }


    public void ActualizarEventoDeportivo(EventoDeportivo ed)
    {
        // Comentario: Borré el boolean 'encontré' porque no es necesario. Previamente ya se comprobó si
        // el Id existe en la reserva

        string archivoTemporal = "archivoTemporal.TXT";

        // 1. Leer el archivo original y escribir en el temporal
        using (var sr = new StreamReader(_nombreArchivo))
        using (var sw = new StreamWriter(archivoTemporal))
        {
            while (!sr.EndOfStream)
            {
                var temp = new EventoDeportivo{
                    Id = int.Parse(sr.ReadLine() ?? ""),
                    Nombre = sr.ReadLine() ?? "",
                    Descripcion = sr.ReadLine() ?? "",
                    FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? ""),
                    DuracionHoras = double.Parse(sr.ReadLine() ?? ""),
                    CupoMaximo = int.Parse(sr.ReadLine() ?? ""),
                    ResponsableId = int.Parse(sr.ReadLine() ?? "")
                };
                
                if (temp.Id == ed.Id)
                {
                    sw.WriteLine(ed.Id);
                    sw.WriteLine(ed.Nombre);
                    sw.WriteLine(ed.Descripcion);
                    sw.WriteLine(ed.FechaHoraInicio);
                    sw.WriteLine(ed.DuracionHoras);
                    sw.WriteLine(ed.CupoMaximo);
                    sw.WriteLine(temp.ResponsableId);
                }
                else
                {
                    sw.WriteLine(temp.Id);
                    sw.WriteLine(temp.Nombre);
                    sw.WriteLine(temp.Descripcion);
                    sw.WriteLine(temp.FechaHoraInicio);
                    sw.WriteLine(temp.DuracionHoras);
                    sw.WriteLine(temp.CupoMaximo);
                    sw.WriteLine(temp.ResponsableId);
                }
            }
        }
        File.Delete(_nombreArchivo);
        File.Move("archivoTemporal.TXT", _nombreArchivo);
    
    }

    public void EliminarEventoDeportivo(int Id)
    {//CONSIDERAR QUE SI HAGO UN BORRADO LOGICO TENGO QUE CAMBIAR EL LISTAR.
        bool encontre = false;// va verificar si se elimino o no.
        using (var sr = new StreamReader(_nombreArchivo))//lo voy a usar para ir leyendo todo mi archivo.
        using (var sw = new StreamWriter("temporal.txt", false))// aca voy a ir escribiendo todo el archivo, con la unica diferencia que concateno 
        {
            while (!sr.EndOfStream)
            {                            // un "*" al evento a borrar(borrado logico).
                List<string> l = new List<string>();// creo una lista para ir guardo los strign que leo y ver si encontre mi id accediendo a l[0].
                for (int i = 0; i < 7; i++)
                {
                    l.Add(sr.ReadLine() ?? "");//voy guardando las lineas que leo a la lista de strings.
                }
                if (!l[0].StartsWith("*") && int.Parse(l[0].ToString()) == Id)
                {// verifico si es el id que busco, pero antes verifico que ya no este borrado.
                    l[0] = "*" + l[0];// si la condicion es true, hago el borrado logico.
                    encontre = true;
                }
                foreach (string e in l)
                {
                    sw.WriteLine(e);//voy escribiendo en mi archivo temporal linea por linea.
                }

            }
        }
        if (encontre)
            {
                Console.WriteLine("Se elimino con exito el evento");
                File.Delete(_nombreArchivo);//borro el archivo ya que no me sirve mas.
                File.Move("temporal.txt", _nombreArchivo);//hago el intercambio con el archivo temporal.
            }
            else
            {
                Console.WriteLine("No se encontro el evento a eliminar");
                File.Delete("temporal.txt");//borro el archivo temporal si no lo encontre.
            }
    }

    public EventoDeportivo BuscarEvento(int id)
    {
        return this.ListarEventoDeportivo().First(e => e.Id == id);
    }

    public bool ExisteId(int id)
    {
        foreach (EventoDeportivo ed in this.ListarEventoDeportivo())
        {
            if (ed.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public bool EsResponsableDeEventoDeportivo(int Id)
    {
        List<EventoDeportivo> listaEventos = ListarEventoDeportivo();

        int i = 0;
        bool encontre = false;

        //Recorro a la list de eventos deportivos, buscando si exista alguno que tenga el mismo ResponsableId
        while (i < listaEventos.Count && !encontre)
        {
            if (listaEventos[i].ResponsableId == Id)
            {
                encontre = true;
            }
            i++;
        }

        return encontre;
    }

    public int DevolverCupoMaximo(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return e.CupoMaximo;
            }
        }
        return 0;
    }

    public bool Expiro(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return e.FechaHoraInicio < DateTime.Now;
            }
        }
        return false;
    }

}