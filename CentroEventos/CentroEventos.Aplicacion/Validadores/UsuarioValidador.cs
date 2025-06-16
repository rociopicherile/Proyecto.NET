namespace CentroEventos.Aplicacion.Validadores;

using CentroEventos.Aplicacion.Interfaces;

public class UsuarioValidador(IRepositorioUsuario repoUsu)
{
    public bool ValidarNombre(string? nombre)
    {
        return !(string.IsNullOrWhiteSpace(nombre));
    }
    public bool ValidarApellido(string? apellido)
    {

        return !(string.IsNullOrWhiteSpace(apellido));
    }
    public bool ValidarEmail(string? email)
    {

        return !(string.IsNullOrWhiteSpace(email));
    }
    public bool ValidarExisteEmail(string email)
    {
        return repoUsu.ExisteEmail(email);
    }

    public bool ValidarExiste(int id)//validacion solo para el eliminar y modificar
    {
        return repoUsu.ExisteId(id);
    }
    public bool ValidarContraseña(string? contraseña)
    {

        return !(string.IsNullOrWhiteSpace(contraseña));
    }

}