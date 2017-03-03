using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CryptoLib
{
    public class Caezar : CryptoBase<int>
    {
        public Caezar(Alphabets alphabet) : base(alphabet)
        {
        }

        public override string Crypt(string text, int offset)
        {
            char[] preparedText = text.ToCharArray();
            for (int i = 0; i < preparedText.Length; i++)
            {
                preparedText[i] = CryptChar(preparedText[i], offset);
            }
            return new string(preparedText);
        }

        public override string Decrypt(string text, int offset)
        {
            char[] preparedText = text.ToCharArray();
            for (int i = 0; i < preparedText.Length; i++)
            {
                preparedText[i] = DecryptChar(preparedText[i], offset);
            }
            return new string(preparedText);
        }
        
    }
}
