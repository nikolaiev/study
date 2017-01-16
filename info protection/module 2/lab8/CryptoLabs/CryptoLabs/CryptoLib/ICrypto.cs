using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    interface ICrypto<TKey>
    {
        string Crypt(String text, TKey key);
        string Decrypt(String text, TKey key);
        string CryptFile(String path, TKey key);
        string DecryptFile(String path, TKey key);
    }
}
