using System.Security.Cryptography;
using System.Text;

namespace SistemaCondominio.Api.Services
{
    public class PasswordService
    {
        public static string Hash(string senha)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }

        public static bool Verify(string senha, string hash)
        {
            return Hash(senha) == hash;
        }
    }
}
