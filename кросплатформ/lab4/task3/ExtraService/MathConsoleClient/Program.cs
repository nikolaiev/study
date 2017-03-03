using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using MathConsoleClient.ServiceReference1;
using System.Threading;
namespace MathConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Async Math Client * ****\n");
        using (CalculatorClient proxy = new
        CalculatorClient())
            {
                proxy.Open();
                // Додавання в асинхронному режимі з
                //використанням лямбда-виразів.

                IAsyncResult result = proxy.BeginTask(123, ar =>
                {
                    Console.WriteLine("Task(123) ={0}", proxy.EndTask(ar));
                }, null);
                while (!result.IsCompleted)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Client working...");
                }
            }
            Console.ReadLine();
        }
    }
}