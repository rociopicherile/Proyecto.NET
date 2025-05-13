/* Falta añadir un archivo para los ID's
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
        List<string?> campos = new List<string?>
        {
            persona.Id.ToString(),
            persona.DNI,
            persona.Nombre + ' ' + persona.Apellido,
            persona.Telefono,
            persona.Email
        };


        // Escribir la línea al archivo, separada por palito
        sw.WriteLine(string.Join('|', campos));
    }

    public void Eliminar(int id){
         // Leer todas las líneas
        List<string> lineas = File.ReadAllLines(_nombreArch).ToList();

        // Buscar y eliminar la línea cuyo ID coincida
        var nuevasLineas = lineas
            .Where(linea => !linea.StartsWith(id.ToString() + '|'))
            .ToList();

        // Sobrescribir el archivo con las nuevas líneas
        File.WriteAllLines(_nombreArch, nuevasLineas);
    }


    public List<Persona> ListarPersona(){
        char[] delimitadores = {'|', ' '};
        List<Persona> lista = new List<Persona>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Persona persona = new Persona();
            // Separo a la línea con Split y guardo cada campo en un vector de string
            string[] linea = sr.ReadLine().Split(delimitadores);
            
            // Introduzco cada elemento del vector en mi objeto persona
            persona.Id = int.Parse(linea[0]);
            persona.DNI = linea[1];
            persona.Nombre = linea[2];
            persona.Apellido = linea[3];
            persona.Telefono = linea[4];
            persona.Email = linea[5];
            lista.Add(persona);
        }

        return lista;
    }
    

    public void Actualizar(Persona persona){
        using var sr = new StreamReader(_nombreArch);
        char[] delimitadores = {'|', ' '};

        // (1) Convierto al archivo en una lista
        List<string> lineas = File.ReadAllLines(_nombreArch).ToList();

        // (2) El vector 'vectorLinea' me sirve para analizar cada línea de forma individual
        int i = 0;
        string[] vectorLinea = lineas[i].Split(delimitadores);
        
        // (3) Recorro la lista buscando a la persona cuyo ID coincida 
       while (i <= lineas.Count && persona.Id.ToString() != vectorLinea[0])
        {
            i++;

            // Divido en partes a cada línea
            vectorLinea = lineas[i].Split(delimitadores);
        }

        // (4) Una vez encontrado el Id, reescribo a la persona
        if (persona.Id.ToString() == vectorLinea[0]){
            lineas[i] = $"{persona.Id}|{persona.DNI}|{persona.Nombre} {persona.Apellido}|{persona.Telefono}|{persona.Email}"; 
        }

        // (5) Reescribo el archivo con la persona modificada
        File.WriteAllLines(_nombreArch, lineas);
    }
}
