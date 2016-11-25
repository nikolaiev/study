using System;

using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.ServiceModel;
using MagicBallServiceLib;
using System.Configuration;

namespace MagicBallServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Console Based WCF Host *****");
            using (ServiceHost serviceHost = new ServiceHost(typeof(MagicBallService)))
            {
                // Відкрити хост і слухати вхідні повідомлення.
                foreach (System.ServiceModel.Description.ServiceEndpoint se in
                serviceHost.Description.Endpoints)
                {
                    Console.WriteLine("Address: {0}", se.Address);
                    Console.WriteLine("Binding: {0}", se.Binding.Name);
                    Console.WriteLine("Contract: {0}", se.Contract.Name);
                    Console.WriteLine();
                }
                serviceHost.Open();
                // Для виходу - натиснути Enter.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate service.");
                Console.ReadLine();
            }
        }
    }
}
