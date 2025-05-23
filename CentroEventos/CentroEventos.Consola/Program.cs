﻿/*
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

// (4) Esto es para vaciar los archivos de texto cada vez que se ejecuta el programa
File.WriteAllText("personas.txt", string.Empty);
File.WriteAllText("eventoDeportivo.txt", string.Empty);
File.WriteAllText("reservas.txt", string.Empty);


// (5) Acá comienzan los casos de prueba (agregar, actualizar, listar y eliminar)

//agregar persona 1 

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


//agregar Persona 3

try
{
    agregarPersona.Ejecutar(1, new Persona
    {
        DNI = "23238322",
        Nombre = "Mick",
        Apellido = "Jagger",
        Email = "mJagger@example.com",
        Telefono = "221-1111111"
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex){Console.WriteLine(ex.Message);}


//agregar Persona 4

try
{
    agregarPersona.Ejecutar(1, new Persona
    {
        DNI = "29111823",
        Nombre = "Leonel",
        Apellido = "Messi",
        Email = "LMessi@example.com",
        Telefono = "221-2222222"
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
        DuracionHoras = 1, // 1 hora 
        CupoMaximo = 200,
        ResponsableId = 2 // ID del organizador
    });
}

catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}


// agregar Evento 2

try
{
    agregarEvento.Ejecutar(1, new EventoDeportivo{
        Nombre = "Voley",
        Descripcion = "Descripción aquí",
        FechaHoraInicio = new DateTime(2025, 11, 15, 13, 0, 0), // 15/11/2025 13:00 AM,
        DuracionHoras = 2.5, //  2 horas y 30 minutos
        CupoMaximo = 200,
        ResponsableId = 1 // ID del organizador
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}



// agregar Evento 3

try
{
    agregarEvento.Ejecutar(1, new EventoDeportivo{
        Nombre = "Basquet",
        Descripcion = "Descripción aquí",
        FechaHoraInicio = new DateTime(2025, 11, 15, 16, 0, 0), // 15/11/2025 13:00 AM,
        DuracionHoras = 2, //  2 horas
        CupoMaximo = 300,
        ResponsableId = 1 // ID del organizador
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}


//Agregar Reserva 1

try
{
    agregarReserva.Ejecutar(1, new Reserva{
        PersonaId = 1,
        EventoDeportivoId = 2,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Pendiente,
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }


//Agregar Reserva 2

try
{
    agregarReserva.Ejecutar(1, new Reserva{
        PersonaId = 2,
        EventoDeportivoId = 2,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Pendiente,
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }


//Agregar Reserva 3

try
{
    agregarReserva.Ejecutar(1, new Reserva{
        PersonaId = 3,
        EventoDeportivoId = 2,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Pendiente,
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }


//agregar Reserva 4

try
{
    agregarReserva.Ejecutar(1, new Reserva{
        PersonaId = 4,
        EventoDeportivoId = 3,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Asistio,
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }


// actualizar Persona (le cambio el mail y el teléfono a Juan Peréz)

try
{
    modificarPersona.Ejecutar(1, new Persona
    {
        Id = 1,
        DNI = "12345678",
        Nombre = "Juan",
        Apellido = "Pérez",
        Email = "juanActualizado@example.com",
        Telefono = "2393-4941"
    });
}
catch (FalloAutorizacionException ex) {Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex) {Console.WriteLine(ex.Message);}



// Actualizar Reserva (actualizo la reserva de Id = 1 y le cambio el estado asistencia)

try
{
    modificarReserva.Ejecutar(1, new Reserva{
        Id = 1,
        PersonaId = 1,
        EventoDeportivoId = 1,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Asistio,
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }



// Actualizar Evento Deportivo (actualizo evento Id = 2 y le cambio la duración horas, la descripción y el cupo)

try
{
    modificarEvento.Ejecutar(1, new EventoDeportivo{
        Id = 2,
        Nombre = "Voley",
        Descripcion = "Descripción actualizada aquí",
        FechaHoraInicio = new DateTime(2025, 11, 15, 13, 0, 0), // 15/11/2025 13:00 AM,
        DuracionHoras = 3, // 3 horas
        CupoMaximo = 2,
        ResponsableId = 1 // ID del organizador
    });
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


//listar

Console.WriteLine("-------------------");
Console.WriteLine("Lista de personas: ");
foreach (Persona p in listarPersona.Ejecutar()){
    Console.WriteLine(p);
}

Console.WriteLine("-------------------");
Console.WriteLine("Lista de reservas: ");
foreach (Reserva r in listarReserva.Ejecutar()){
    Console.WriteLine(r);
}


Console.WriteLine("-------------------");
Console.WriteLine("Lista de Eventos: ");
foreach (EventoDeportivo ed in listarEvento.Ejecutar()){
    Console.WriteLine(ed);
}


Console.WriteLine("-------------------");
Console.WriteLine("Lista de Eventos con cupo disponible: ");
foreach (EventoDeportivo ed in listarEventoConCupoDisponible.Ejecutar()){
    Console.WriteLine(ed);
}

Console.WriteLine("-------------------");
Console.WriteLine("Lista de asistencias: ");
foreach (Persona p in listarAsistencia.Ejecutar()){
    Console.WriteLine(p);
}

