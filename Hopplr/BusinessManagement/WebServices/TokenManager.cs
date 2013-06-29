using System;
using System.Linq;

namespace BusinessManagement.WebServices
{
    public class TokenManager
    {
        public static string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.Now.ToBinary());
            byte[] key = new Guid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        public static bool IsTokenValid(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime creationDate = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            return creationDate > DateTime.Now.AddDays(-1);
        }

        public static string EncryptToken(string token)
        {
            return token;
        }

        public static string DecryptToken(string crytedToken)
        {
            return crytedToken;
        }
    }
}
