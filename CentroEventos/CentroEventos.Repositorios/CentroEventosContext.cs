// Belén

namespace CentroEventos.Repositorios;

using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;


public class CentroEventosContext : DbContext
{

    // (1) Definir las tablas (DbSet = colección de entidades)
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }

    // (2) Configurar la conexión a la BD (SQLite)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }
}