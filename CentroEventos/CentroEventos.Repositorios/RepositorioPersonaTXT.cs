/* Supongo que para crear un ID único para personas debería tener un método que recorra al archivo hasta
el final y lea el último ID, entonces al nuevo elemento se le tiene que asignar IDFinal + 1.

Falta implementar el resto de métodos (CRUD)

*/

namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
public class RepositorioPersonaTXT /*:  IRepositorioPersona*/ {
    readonly string _nombreArch = "personas.txt";
    public void Agregar(Persona persona)
    {
        // Completar: persona.Id = GenerarNuevoId();
        using var sw = new StreamWriter(_nombreArch, true);

        // Crear una lista de los campos comunes
        List<string> campos = new List<string>
        {
            persona.Id.ToString(),
            persona.GetType().Name,
            persona.DNI,
            persona.Nombre,
            persona.Apellido,
            persona.Telefono,
            persona.Email
        };


        // Escribir la línea al archivo, separada por guión
        sw.WriteLine(string.Join(" - ", campos));
    }

    public void Eliminar(int id){
         // Leer todas las líneas
        List<string> lineas = File.ReadAllLines(_nombreArch).ToList();

        // Buscar y eliminar la línea cuyo ID coincida
        var nuevasLineas = lineas
            .Where(linea => !linea.StartsWith(id + " - "))
            .ToList();

        // Sobrescribir el archivo con las nuevas líneas
        File.WriteAllLines(_nombreArch, nuevasLineas);
    }

    /*
    public List<Persona> ListarPersona(){
        List<Persona> lista = new List<Persona>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Persona persona = new Persona();
            persona.Id = int.Parse(sr.ReadLine() ?? "");
            persona.Nombre = sr.ReadLine() ?? "";
            persona.Apellido = int.Parse(sr.ReadLine() ?? "");
            lista.Add(persona);
        }
        return lista;
    }
    */

    public void Actualizar(Persona persona){
        // Completar
    }

    
}
