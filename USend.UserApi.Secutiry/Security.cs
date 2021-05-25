using System;
using System.Text;

namespace USend.UserApi.Secutiry
{
    public static class Security
    {
        public static string Encrypt(string text)
        {
            byte xorConstant = 0x53;

            byte[] data = Encoding.UTF8.GetBytes(text);
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)(data[i] ^ xorConstant);

            return Convert.ToBase64String(data);
        }
    }
}
