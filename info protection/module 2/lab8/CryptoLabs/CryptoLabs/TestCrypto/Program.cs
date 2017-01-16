using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoLib;

namespace TestCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamma cz=new Gamma(Alphabets.English);
            string tmp = cz.Crypt("Hello", 1);
            Console.WriteLine(tmp);

            Console.WriteLine(cz.Decrypt(tmp,1));
            //Console.WriteLine(cz.Crypt("ацупа цуарнгшмуркап гшцруао9237не238 9кнрг32оа 8239кг23анмгш34екн3м рукшоп43цум", 3));
            Console.ReadLine();
        }
    }
}
