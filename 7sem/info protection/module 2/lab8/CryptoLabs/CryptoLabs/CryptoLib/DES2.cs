using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public class DES2
    {
        public String Crypt(byte[] data, String key)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(key)),
                CryptoStreamMode.Write);
            memoryStream.Write(data,0,data.Length);
            cryptoStream.FlushFinalBlock();
            var result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            memoryStream.Close();
            cryptoStream.Close();
            //writer.Close();
            return result;
        }

        public String Decrypt(byte[] data, String key)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                CryptoStream cryptoStream = new CryptoStream(new MemoryStream(data), 
            cryptoProvider.CreateDecryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(key)), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            var result = reader.ReadToEnd();
            cryptoStream.Close();
            reader.Close();
            return result;
        }
    }
}
