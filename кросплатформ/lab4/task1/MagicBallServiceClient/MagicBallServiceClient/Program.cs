using System;
using System.Collections.Generic;
using System.Text;
using MagicBallServiceClient.ServiceReference1;

namespace MagicBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string question;
            Console.WriteLine("***** Ask magic ball *****\n");
            using (MagicBallClient ball = new MagicBallClient())
            {
                do
                {
                    Console.Write("Your number: ");
                    question = Console.ReadLine();
                    if (question != "")
                    {
                        string answer = ball.ObtainAnswerToQuestion(question);
                        Console.WriteLine("Magic ball: {0}", answer);
                    }
                } while (question != "");
            }
        }
    }
}