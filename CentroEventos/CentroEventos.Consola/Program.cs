/*
Desde aquí se debería probar el funcionamiento del programa. 
Se debe poder registrar personas, eventos deportivos y gestionar reservas
*/
    

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Agregar;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Eliminar;
using CentroEventos.Aplicacion.Excepciones;

// (1) Inicializar repositorios y servicio de autorización
var repoPersona = new RepositorioPersonaTXT();
var repoEventoDeportivo = new RepositorioEventoDeportivoTXT();
var repoReserva = new RepositorioReservaTXT();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// (2) Inicializar validadores
var validadorPersona = new PersonaValidador(repoPersona, repoReserva, repoEventoDeportivo);
var validadorEventoDeportivo = new EventoDeportivoValidador(repoEventoDeportivo, repoPersona, repoReserva);
var validadorReserva = new ReservaValidador(repoPersona, repoEventoDeportivo, repoReserva);

//(3) inicializar casos de uso

//create
var agregarPersona = new AgregarPersonaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var agregarReserva = new AgregarReservaUseCase(repoReserva, validadorReserva, servicioAutorizacion);
var agregarEvento = new AgregarEventoDeportivoUseCase(repoEventoDeportivo,validadorEventoDeportivo,servicioAutorizacion);

//update
var modificarPersona = new ActualizarPersonaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var modificarReserva = new ActualizarReservaUseCase(repoReserva, validadorReserva, servicioAutorizacion);
var modificarEvento = new ActualizarEventoDeportivoUseCase(repoEventoDeportivo, validadorEventoDeportivo, servicioAutorizacion);

//delete
var eliminarPersona = new EliminarPersonaUseCase(repoPersona,validadorPersona,servicioAutorizacion);
var eliminarReserva = new EliminarReservaUseCase(repoReserva,validadorReserva,servicioAutorizacion);
var eliminarEvento = new EliminarEventoDeportivoUseCase(repoEventoDeportivo, validadorEventoDeportivo, servicioAutorizacion);

//read
var listarPersona = new ListarPersonaUseCase(repoPersona);
var listarReserva = new ListarReservaUseCase(repoReserva);
var listarEvento = new ListarEventoDeportivoUseCase(repoEventoDeportivo);
var listarEventoConCupoDisponible = new ListarEventoDeportivoConCupoDisponibleUseCase(repoEventoDeportivo,repoReserva);
var listarAsistencia = new ListarAsistenciaAEventoUseCase(repoReserva, repoPersona, repoEventoDeportivo);


File.WriteAllText("personas.txt", string.Empty);
File.WriteAllText("eventos.txt", string.Empty);
File.WriteAllText("reservas.txt", string.Empty);

//agregar Persona
try
{
    agregarPersona.Ejecutar(1, new Persona
    {
        DNI = "12345678",
        Nombre = "Juan",
        Apellido = "Pérez",
        Email = "juan@example.com",
        Telefono = "555-1234"
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex){Console.WriteLine(ex.Message);}

//agregar Persona 2
try
{
    agregarPersona.Ejecutar(1, new Persona
    {
        DNI = "2323842",
        Nombre = "Stevie",
        Apellido = "Wonder",
        Email = "Stevie@example.com",
        Telefono = "233-4904"
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex){Console.WriteLine(ex.Message);}


//agregar Evento

try
{
    agregarEvento.Ejecutar(1, new EventoDeportivo{
        Nombre = "Fútbol",
        Descripcion = "Descripción aquí",
        FechaHoraInicio = new DateTime(2025, 11, 15, 9, 0, 0), // 15/11/2025 09:00 AM,
        DuracionHoras = 1.5, // 1 hora y 30 minutos
        CupoMaximo = 200,
        ResponsableId = 1 // ID del organizador
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}

//Agregar Reserva

/*
try
{
    agregarReserva.Ejecutar(1, new Reserva{
        EventoDeportivoId = "1",
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = "",
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }





/*
// actualizar Persona

try
{
    modificarPersona.Ejecutar(1, new Persona());
}
catch (FalloAutorizacionException ex) {Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex) {Console.WriteLine(ex.Message);}

// actulizar Reserva

try
{
    modificarReserva.Ejecutar(1, new Reserva());
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }

// actulizar Evento

try
{
    modificarEvento.Ejecutar(1, new EventoDeportivo());
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (OperacionInvalidaException ex) { Console.WriteLine(ex.Message); }

// eliminar Persona

try
{
    eliminarPersona.Ejecutar(1, 1);
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (OperacionInvalidaException ex) { Console.WriteLine(ex.Message); }

// eliminar Reserva

try
{
    eliminarReserva.Ejecutar(1,1);
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }

// eliminar evento

try
{
    eliminarEvento.Ejecutar(1, 1);
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (OperacionInvalidaException ex) { Console.WriteLine(ex.Message); }

//listar no se si tiene try and catch

listarPersona.Ejecutar();
listarReserva.Ejecutar();
listarEvento.Ejecutar();
listarAsistencia.Ejecutar();
listarEventoConCupoDisponible.Ejecutar();

*/