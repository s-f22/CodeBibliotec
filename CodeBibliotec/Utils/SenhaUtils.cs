using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;

namespace CodeBibliotec.Utils
{
    public class SenhaUtils
    {
        private const string SaltFixo = "Bibliotec_Salt_Seguro";

        public static string HashSenha(string senha)
        {
            string senhaComSalt = senha + SaltFixo;

            using var sha256 = SHA256.Create();
            byte[] bytesHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaComSalt));

            return Convert.ToHexString(bytesHash).ToLower();
        }



        public static bool VerificarSenha(string senhaInformada, string hashArmazenado)
        {
            string hashComputado = HashSenha(senhaInformada);

            return string.Equals(hashComputado, hashArmazenado, StringComparison.OrdinalIgnoreCase);
        }


        public static bool EstaHashada(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return false;

            return senha.Length == 64 && senha.All(c => "0123456789abcdef".Contains(c));

        }

    }
}
