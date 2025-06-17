namespace CentroEventos.Aplicacion.Seguridad;

using System.Security.Cryptography;
using System.Text;
public static class ContraseñaHash
{
    public static string Hash(string contraseña)
    {
        // creo una instancia del algoritmo de hash SHA-256
        using var sha256 = SHA256.Create();

        // convierto la contraseña (string) en un array de bytes usando codificación UTF-8
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

        // convierto el array de bytes del hash en una cadena Base64
        return Convert.ToBase64String(bytes);
    }
}