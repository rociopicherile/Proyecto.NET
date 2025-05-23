// Terminado (creo)
// Hecho por: Sebas y Matías



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

public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly string _nombreArch = "reservas.txt";
    readonly string _archivoIds = "IDsReservas.txt";
    private int _idUltimo;
    public RepositorioReservaTXT()
    {
        using var sw = new StreamWriter(_archivoIds);
        sw.WriteLine("0");
    }
    public List<Reserva> ListarReserva()
    {
        var resultado = new List<Reserva>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var r = new Reserva();
            r.Id = int.Parse(sr.ReadLine() ?? "");
            r.PersonaId = int.Parse(sr.ReadLine() ?? "");
            r.EventoDeportivoId = int.Parse(sr.ReadLine() ?? "");
            r.FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? "");
            r.EstadoAsistencia = (EstadoAsistencia)Enum.Parse(typeof(EstadoAsistencia), sr.ReadLine() ?? "");//
            resultado.Add(r);
        }
        return resultado;
    }

    public void AgregarReserva(Reserva p)
    {
        _idUltimo++;
        p.Id = _idUltimo;//decirle a belen que cambie la linea de codigo
        using var sw2 = new StreamWriter(_archivoIds, false);
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(p.Id);
        sw.WriteLine(p.PersonaId);
        sw.WriteLine(p.EventoDeportivoId);
        sw.WriteLine(p.FechaAltaReserva);
        sw.WriteLine(p.EstadoAsistencia);
    }


    public void ActualizarReserva(Reserva r)
    {
        // Comentario: Borré el boolean 'encontré' porque no es necesario. Previamente ya se comprobó si
        // el Id existe en la reserva

        string archivoTemporal = "archivoTemporal.TXT";

        // 1. Leer el archivo original y escribir en el temporal
        using (var sr = new StreamReader(_nombreArch))
        using (var sw = new StreamWriter(archivoTemporal))
        {
            while (!sr.EndOfStream)
            {
                var temp = new Reserva
                {
                    Id = int.Parse(sr.ReadLine() ?? ""),
                    PersonaId = int.Parse(sr.ReadLine() ?? ""),
                    EventoDeportivoId = int.Parse(sr.ReadLine() ?? ""),
                    FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? ""),
                    EstadoAsistencia = (EstadoAsistencia)Enum.Parse(typeof(EstadoAsistencia), sr.ReadLine() ?? "")
                };

                if (temp.Id == r.Id)
                {
                    // Escribir la reserva actualizada
                    sw.WriteLine(r.Id);
                    sw.WriteLine(r.PersonaId);
                    sw.WriteLine(r.EventoDeportivoId);
                    sw.WriteLine(r.FechaAltaReserva);
                    sw.WriteLine(r.EstadoAsistencia);
                }
                else
                {
                    // Escribir la reserva sin cambios
                    sw.WriteLine(temp.Id);
                    sw.WriteLine(temp.PersonaId);
                    sw.WriteLine(temp.EventoDeportivoId);
                    sw.WriteLine(temp.FechaAltaReserva);
                    sw.WriteLine(temp.EstadoAsistencia);
                }
            }
        } // Los recursos se liberan aquí automáticamente

        File.Delete(_nombreArch);
        File.Move(archivoTemporal, _nombreArch);
    }

    public void EliminarReserva(int Id)
    {
        bool encontre = false;
        using (var sr = new StreamReader(_nombreArch))//lo voy a usar para ir leyendo todo mi archivo.
        using (var sw = new StreamWriter("temporal.txt", false))
        {
            // SIEMPRE EN FALSE YA QUE SI NO POR CADA LLAMADA SE SIGUE SOBREESCRIBIENDO 
            while (!sr.EndOfStream)
            {
                List<string> l = new List<string>();// creo una lista para ir guardo los strign que leo y ver si encontre mi id accediendo a l[0].
                for (int i = 0; i < 5; i++)
                {
                    l.Add(sr.ReadLine() ?? "");//voy guardando las lineas que leo a la lista de strings.
                }
                if (!(int.Parse(l[0].ToString()) == Id))
                {
                    foreach (string e in l)
                    {
                        sw.WriteLine(e);//voy escribiendo en mi archivo temporal linea por linea.
                    }
                }
                else
                {
                    encontre = true;//innecesario unicamente para imprimir si se encontro o no. Podria unicamente siempre pasar el
                }                 //archivo temporal al verdadero archivo y listo, pero lo haria innecesariamente. 
            }
        }
        if (encontre)
            {
                Console.WriteLine("Se elimino con éxito la reserva");
                File.Delete(_nombreArch);//borro el archivo ya que no me sirve mas.
                File.Move("temporal.txt", _nombreArch);//hago el intercambio con el archivo temporal.
            }
            else
            {
                Console.WriteLine("No se encontro la reserva a eliminar");
                File.Delete("temporal.txt");//borro el archivo temporal si no lo encontre.
            }
    }

    public bool Reservo(int idP, int idE)
    {
        foreach (Reserva n in this.ListarReserva())
        {
            if (n.PersonaId == idP)
            {
                if (n.EventoDeportivoId == idE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int CantidadDeReservas(int id)
    {//devuelve la cantidad de personas que reservaron en un evento cuyo id se pasa por parametro
        int total = 0;
        foreach (Reserva r in this.ListarReserva())
        {
            if (r.EventoDeportivoId == id)
            {
                total++;
            }
        }
        return total;
    }

    public bool EventoTieneReservaAsociada(int Id)
    {
        List<Reserva> listaReservas = ListarReserva();

        int i = 0;
        bool encontre = false;

        //Recorro a la list de reservas, buscando si exista alguna que tenga el mismo EventoDeportivoId
        while (i < listaReservas.Count && !encontre)
        {
            if (listaReservas[i].EventoDeportivoId == Id)
            {
                encontre = true;
            }
            i++;
        }

        return encontre;
    }

    public bool PersonaTieneReservaAsociada(int Id)
    {
        List<Reserva> listaReservas = ListarReserva();

        int i = 0;
        bool encontre = false;

        //Recorro a la list de reservas, buscando si exista alguna que tenga el mismo PersonaId
        while (i < listaReservas.Count && !encontre)
        {
            if (listaReservas[i].PersonaId == Id)
            {
                encontre = true;
            }
            i++;
        }

        return encontre;
    }

    public bool ExisteId(int id)
    {
        foreach (Reserva r in this.ListarReserva())
        {
            if (r.Id == id)
            {
                return true;
            }
        }
        return false;
    }

}