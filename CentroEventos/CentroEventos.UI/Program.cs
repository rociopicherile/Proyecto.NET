using CentroEventos.Aplicacion.CasosDeUsos.Actualizar;
using CentroEventos.Aplicacion.CasosDeUsos.Agregar;
using CentroEventos.Aplicacion.CasosDeUsos.Eliminar;
using CentroEventos.Aplicacion.CasosDeUsos.Listar;
using CentroEventos.Aplicacion.Loggin;
using CentroEventos.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<AgregarPersonaUseCase>();
builder.Services.AddTransient<EliminarPersonaUseCase>();
builder.Services.AddTransient<ListarPersonaUseCase>();
builder.Services.AddTransient<ActualizarPersonaUseCase>();
builder.Services.AddScoped<LogginUseCase>();
builder.Services.AddScoped<UsuarioSesion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
