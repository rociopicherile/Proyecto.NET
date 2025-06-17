namespace CentroEventos.Aplicacion.Loggin;

using System;
using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Seguridad;



public class LogingUseCase(IRepositorioUsuario repo, UsuarioValidador validador)
{
    public Usuario Ejecutar(string email, string password)
    {
        var usuario = repo.BuscarUsuarioPorEmail(email) ?? throw new LogingException("no existe un usuario con el mail ingresado");

        if (string.IsNullOrWhiteSpace(password))
            throw new LogingException("La contraseña no puede estar vacía.");

        var hashIngresado = ContraseñaHash.Hash(password);

        var hashRepo = usuario.Contraseña;

        if (!hashIngresado.Equals(hashRepo))
        {
            throw new LogingException("Contraseña incorrecta");
        }

        return usuario;

    }


}