using System.Security.Cryptography;
using System.Text;

namespace Api.Helper
{
    public class PasswordHasher
    {
        public static byte[] Hash(string password)
        {
            // TODO: Salt password
            using SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}