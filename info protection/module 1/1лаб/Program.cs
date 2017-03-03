using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Password");
            String password=Console.ReadLine();
            
            if (password == "123abc")
                Console.WriteLine("Congratulation!");
            else
                return;
            Console.ReadKey();
        }
    }
}
