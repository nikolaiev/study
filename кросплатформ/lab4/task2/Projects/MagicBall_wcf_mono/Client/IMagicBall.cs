using System;
using System.ServiceModel;
namespace Client
{
	[ServiceContract]
	public interface IMagicBall
	{
		// Отримати відповідь на питання!
		[OperationContract]
		string ObtainAnswerToQuestion(string userQuestion);
	}
}
