using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Map.Helpers
{
    public static class NHelper
    {
        public static string ToMD5(this string str)
        {
            string toMD5 = string.Empty;
            using (MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(GetBytes(str+"woody"));
                toMD5 = BitConverter.ToString(hash);
            }
            return toMD5;
        }

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
