using System;
using System.ServiceModel;
namespace Client
{
	class MainClass
	{
		static void Main(string[] args)
		{
			string question;
			Console.WriteLine("*****Ask Magic Ball*****\n");
			BasicHttpBinding binding = new BasicHttpBinding();
			var address = new EndpointAddress("http://localhost:8080");
			var ball = new MyServiceClient(binding, address);
			do
			{
				Console.Write("Yout number: ");
				question = Console.ReadLine();
				if (question != "")
				{
					Console.WriteLine("MagicBall answer: {0} ...",
					ball.ObtainAnswerToQuestion(question));
				}
			} while (question != "");
			Console.ReadLine();
		}
	}
}