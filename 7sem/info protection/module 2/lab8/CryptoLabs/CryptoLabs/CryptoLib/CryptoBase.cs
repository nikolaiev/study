using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public abstract class CryptoBase<TKey>:ICrypto<TKey>
    {
        protected CryptoBase(Alphabets alphabet)
        {
            Alphabet = alphabet;
        }

        protected Alphabets _alphabet = Alphabets.English;
        protected string _currentAlphabet;

        protected const string UkrainianAlphabet =
            "йцукенгшщзхїфівапролджєячсмитьбюЙЦУКЕНГШЩЗХЇФІВАПРОЛДЖЄЯЧСМИТЬБЮ.,!-? \n\t";

        protected const string EnglishAlphabet = "qwertyuiopasdfghjkllzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM.,!-? \n\t";

        public Alphabets Alphabet
        {
            get { return _alphabet; }
            set
            {
                _alphabet = value;
                switch (value)
                {
                    case Alphabets.Ukrainian:
                        {
                            _currentAlphabet = UkrainianAlphabet;
                            break;
                        }
                    default:
                        {
                            _currentAlphabet = EnglishAlphabet;
                            break;
                        }
                }
            }
        }

        public static int GetAlphabetLenght(Alphabets alphabet)
        {
            switch (alphabet)
            {
                case Alphabets.English:
                {
                    return EnglishAlphabet.Length;
                }
                case Alphabets.Ukrainian:
                {
                    return UkrainianAlphabet.Length;
                }
            }
            return 0;
        }

        public abstract string Crypt(string text, TKey key);
        public abstract string Decrypt(string text, TKey key);

        protected char CryptChar(char ch, int offset)
        {
            if (_currentAlphabet.Contains(ch))
            {
                int index = (_currentAlphabet.IndexOf(ch) + offset) % (_currentAlphabet.Length);
                if (index < 0)
                {
                    index += _currentAlphabet.Length;
                }
                return _currentAlphabet[index];
            }
            throw new ArgumentException(ch.ToString());
        }

        protected char DecryptChar(char ch, int offset)
        {
            if (_currentAlphabet.Contains(ch))
            {
                int tmpCharNumber = (_currentAlphabet.IndexOf(ch) - offset) % _currentAlphabet.Length;
                if (tmpCharNumber < 0)
                {
                    tmpCharNumber += _currentAlphabet.Length;
                }
                return _currentAlphabet[tmpCharNumber];
            }
            throw new ArgumentException(ch.ToString());
        }

        public string CryptFile(string path, TKey key)
        {
            if (path != null && File.Exists(path))
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                return Crypt(text, key);
            }
            return String.Empty;
        }

        public string DecryptFile(string path, TKey key)
        {
            if (path != null && File.Exists(path))
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                return Decrypt(text, key);
            }
            return String.Empty;
        }
    }
}
