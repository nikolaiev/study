using System;
using MyLibLab3;
class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Type the number");
		string s = Console.ReadLine();
		int N;
		while (!s.Equals(""))
		{
			N = Int32.Parse(s);
			Result res=Binary.Resolve(N);
			Console.WriteLine("Binary representation :");
			Console.WriteLine(res.binarStr);
			Console.WriteLine("Ones amount :");
			Console.WriteLine(res.count);
			s = Console.ReadLine();
		}
	}
}