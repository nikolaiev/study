using System;
using System.ServiceModel;
using Service;
namespace Host
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("WCF Host for MagicBall!");
			BasicHttpBinding binding = new BasicHttpBinding();
			Uri address = new Uri("http://localhost:8080");
			ServiceHost host = new ServiceHost(typeof(MagicBallService));
			host.AddServiceEndpoint(
			typeof(IMagicBall), binding, address);
			
		host.Open();
			Console.WriteLine("Type Enter to stop ...");
			Console.ReadLine();
			host.Close();
		}
	}
}