using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CryptoLib;
using info.lundin.Math;

namespace CryptoLib
{
    public class Tritemium:CryptoBase<string>
    {
        private bool _isKeyExpression;
        public Tritemium(Alphabets alphabet, bool isKeyExpression):base(alphabet)
        {
            _isKeyExpression = isKeyExpression;
        }

        public override string Crypt(string text, string expression)
        {
            char[] preparedText = text.ToCharArray();
            if (_isKeyExpression)
            {
                for (int i = 0; i < preparedText.Length; i++)
                {
                    preparedText[i] = CryptChar(preparedText[i], CalculateExpressionOffset(i, expression));
                }
            }
            else
            {
                for (int i = 0; i < preparedText.Length; i++)
                {
                    preparedText[i] = CryptChar(preparedText[i], CalculateMottoOffset(i, expression));
                }
            }
            return new string(preparedText);
        }

        private int CalculateExpressionOffset(int t,string expression)
        {
            try
            {
                ExpressionParser expressionParser = new ExpressionParser();
                Hashtable variables = new Hashtable();
                variables.Add("t", t.ToString());
                double result = expressionParser.Parse(expression, variables);
                return (int) result;
            }
            catch
            {
                throw new ArgumentException("Incorrect expression!");
            }
        }

        private int CalculateMottoOffset(int t, string text)
        {
            if (_currentAlphabet.Contains(text[t%text.Length]))
            {
                return _currentAlphabet.IndexOf(text[t%text.Length]);
            }
            throw new ArgumentOutOfRangeException("Incorrect symbol '"+text[t%text.Length]+"' in motto!");
        }

        public override string Decrypt(string text, string expression)
        {
            char[] preparedText = text.ToCharArray();
            if (_isKeyExpression)
            {
                for (int i = 0; i < preparedText.Length; i++)
                {
                    preparedText[i] = DecryptChar(preparedText[i], CalculateExpressionOffset(i, expression));
                }
            }
            else
            {
                for (int i = 0; i < preparedText.Length; i++)
                {
                    preparedText[i] = DecryptChar(preparedText[i], CalculateMottoOffset(i, expression));
                }
            }
            return new string(preparedText);
        }

    }
}
