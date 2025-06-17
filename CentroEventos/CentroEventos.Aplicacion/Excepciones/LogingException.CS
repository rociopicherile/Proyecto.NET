using System;

namespace CentroEventos.Aplicacion;

public class LogingException:Exception
{
    public LogingException(string mensaje):base(mensaje){}
}