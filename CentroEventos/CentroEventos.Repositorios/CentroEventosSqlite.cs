
// Belén
// Como hay que usar la estrategia Code First (Primero escribimos el código y al ejecutarlo
// se genera la base de datos por sí sola), es necesario crear esta clase que se encarga
// únicamente de inicializar la base de datos.

namespace CentroEventos.Repositorios;

public class EscuelaSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }
}