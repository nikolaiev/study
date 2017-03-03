using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public class DES:ICrypto<String>
    {
        public String Crypt(String data, String key)
        {
            verifyData(data);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(key)),
                CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(data);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            var result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
            memoryStream.Close();
            cryptoStream.Close();
            writer.Close();
            return result;
        }

        public String Decrypt(String data, String key)
        {
            verifyData(data);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(data));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateDecryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(key)), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            var result = reader.ReadToEnd();
            cryptoStream.Close();
            memoryStream.Close();
            reader.Close();
            return result;
        }

        private void verifyData(String data)
        {
            if (String.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
        }

        public string CryptFile(string path, String key)
        {
            if (!String.IsNullOrEmpty(path) && File.Exists(path))
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                return Crypt(text, key);
            }
            return String.Empty;
        }

        public string DecryptFile(string path, String key)
        {
            if (!String.IsNullOrEmpty(path) && File.Exists(path))
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                return Decrypt(text, key);
            }
            return String.Empty;
        }

    }
}
