using System;

namespace CryptoLib
{
    public class Gamma:CryptoBase<int>
    {
        public Gamma(Alphabets alphabet):base(alphabet)
        {
        }

        public override string Crypt(string text, int key)
        {
            char[] preparedText = text.ToCharArray();
            var rnd=new Random(key);
            for (int i = 0; i < preparedText.Length; i++)
            {
                preparedText[i] = CryptChar(preparedText[i], rnd.Next(GetAlphabetLenght(_alphabet),Int32.MaxValue));
            }
            return new string(preparedText);
        }
        public override string Decrypt(string text, int key)
        {
            char[] preparedText = text.ToCharArray();
            var rnd=new Random(key);
            for (int i = 0; i < preparedText.Length; i++)
            {
                preparedText[i] = DecryptChar(preparedText[i], rnd.Next(GetAlphabetLenght(_alphabet), Int32.MaxValue));
            }
            return new string(preparedText);
        }
    }
}
