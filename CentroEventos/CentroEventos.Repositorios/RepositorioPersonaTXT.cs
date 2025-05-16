/* 
Esto lo hice yo (Rocío Belén)
Esta clase está terminada, no falta nada (creo)
*/

namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
public class RepositorioPersonaTXT :  IRepositorioPersona {
    readonly string _nombreArch = "personas.txt";
    readonly string _archivoIds = "IDs.txt";
    private int _idUltimo;

    public RepositorioPersonaTXT(){
        using var sr = StreamReader(_archivoIds);
        _idUltimo = int.Parse(sr.ReadToEnd());
    }
    public void AgregarPersona(Persona persona)
    {   
        using var sw2 = StreamWriter(_archivoIds, false);
        _idUltimo++;
        persona.Id = _idUltimo;

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
        sw2.WriteLine(_idUltimo);
    }

    public void EliminarPersona(int id){
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
    
    public void ActualizarPersona(Persona persona){

        //Creo la lista con los datos del archivo
        List<Persona> lista = ListarPersona();
        int i = 0;

        //Busco a la persona en la lista según su id
        while(i < lista.Count && persona.Id != lista[i].Id){
            i++;
        }

        //Una vez encontrada, la actualizo en mi lista
        if (persona.Id == lista[i].Id){
            lista[i] = persona;
        }

        //Creo una lista de strings (para poder utilizar el método WriteAllLines)
        List<string> lineas = new List<string>();
    
        // Por cada elemento de mi lista de Personas, lo añado como string a mi lista de strings 
        foreach (var p in lista)
        {
            lineas.Add($"{p.Id}|{p.DNI}|{p.Nombre}|{p.Apellido}|{p.Telefono}|{p.Email}");
        }

        // 5. Sobrescribir al archivo con las líneas nuevas
        File.WriteAllLines(_nombreArch, lineas);
    }

    public bool ExisteDNI(string dni){
        foreach(Persona p in this.ListarPersona()){
            if(p.dni == dni){
                return true;
            }
        }
        return false;
    }

    public bool ExisteEmail(string email){
        foreach(Persona p in this.ListarPersona()){
            if(p.Email == email){
                return true;
            }
        }
        return false;
    }

    public bool ExisteId(int id){
        foreach(Persona p in this.ListarPersona()){
            if(p.Id == id){
                return true;
            }
        }
        return false;
    }
}
