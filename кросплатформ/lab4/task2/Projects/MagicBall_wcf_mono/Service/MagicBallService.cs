using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MagicBallService" in both code and config file together.
	public class MagicBallService : IMagicBall
	{
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

		public MagicBallService()
		{
			Console.WriteLine("Magic Ball answers...");
		}
		public string ObtainAnswerToQuestion(string userQuestion)
		{

			int val;
			try
			{
				val = Int32.Parse(userQuestion);
			}
			catch (Exception)
			{
				return "You entered not a number! " + userQuestion;
			}
			string result = Convert.ToString(val, 2);
			val = 0;
			foreach (char x in result)
			{
				if (x.Equals('1'))
				{
					val++;
				}

			}
			result += " " + val;

			return result;
		}


	}
}
