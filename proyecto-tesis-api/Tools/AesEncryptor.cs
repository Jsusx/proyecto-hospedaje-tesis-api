using System;
using System.Security.Cryptography;
using System.Text;

namespace proyecto_tesis_api.Tools
{
    public class AesEncryptor
    {
        AesCryptoServiceProvider c;


        public AesEncryptor()
        {
            c = new AesCryptoServiceProvider();

            c.BlockSize = 128;
            c.KeySize = 256;
            c.Mode = CipherMode.CBC;
            c.Key = Encoding.UTF8.GetBytes("TESIS_API_ENCRYPTION_KEY_JESUSSM");
            c.IV = Encoding.UTF8.GetBytes("TESIS_API_ENC_IV");
            c.Padding = PaddingMode.PKCS7;



        }

        public string Encrypt(string text)
        {
            ICryptoTransform t = c.CreateEncryptor();
            byte[] b = t.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(text), 0, text.Length);
            string r = Convert.ToBase64String(b);

            return r;

        }

        public string Decrypt(string encode_text)
        {
            ICryptoTransform ict = c.CreateDecryptor();

            byte[] encbytes = Convert.FromBase64String(encode_text);
            byte[] decbytes = ict.TransformFinalBlock(encbytes, 0, encbytes.Length);

            string r = ASCIIEncoding.ASCII.GetString(decbytes);

            return r;
        }


    }
}
