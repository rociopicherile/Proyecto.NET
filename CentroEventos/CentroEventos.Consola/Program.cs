/*
Desde aquí se debería probar el funcionamiento del programa. 
Se debe poder registrar personas, eventos deportivos y gestionar reservas
*/
    

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Agregar;
using CentroEventos.Aplicacion;

// (1) Inicializar repositorios y servicio de autorización
var repoPersona = new RepositorioPersonaTXT();
var repoEventoDeportivo = new RepositorioEventoDeportivoTXT();
var repoReserva = new RepositorioReservaTXT();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// (2) Inicializar validadores
var validadorPersona = new PersonaValidador(repoPersona, repoReserva, repoEventoDeportivo);
var validadorEventoDeportivo = new EventoDeportivoValidador(repoEventoDeportivo, repoPersona, repoReserva);
var validadorReserva = new ReservaValidador(repoPersona, repoEventoDeportivo, repoReserva);
