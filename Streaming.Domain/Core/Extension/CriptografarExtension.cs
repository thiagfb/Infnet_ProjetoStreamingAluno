using System.Security.Cryptography;
using System.Text;

namespace Streaming.Domain.Core.Extension
{
    public static class CriptografarExtension
    {
        public static string EncryptPassword(this string plainText)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(plainText);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
