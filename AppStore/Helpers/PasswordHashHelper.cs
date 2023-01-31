using System.Security.Cryptography;
using System.Text;

namespace AppStore.Helpers
{
    public class PasswordHashHelper
    {
        public static string HashPassword(string password)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
