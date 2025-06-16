
using System.Security.Cryptography;
using System.Text;
public static class ContraseñaHash
{
    public static string Hash(string contraseña)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
        return Convert.ToBase64String(bytes);
    }
}