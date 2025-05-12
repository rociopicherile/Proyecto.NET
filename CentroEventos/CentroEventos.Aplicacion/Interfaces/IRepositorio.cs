
/* De esta interfaz deberían derivar las otras interfaces. Esta es la que maneja 
el CRUD Básico.

CRUD : Create, Read, Update, Delete 
*/
public interface IRepositorio<T> where T : class
{
    // Create
    void Agregar(T entidad);

    // Delete
    void Eliminar(int id);

    // Update
    void Actualizar(T entidad);

    // Read
    List<T> Listar();
}