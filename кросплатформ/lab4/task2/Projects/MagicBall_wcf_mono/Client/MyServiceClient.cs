using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Client
{
	public class MyServiceClient : ClientBase<IMagicBall>, IMagicBall
	{
		public MyServiceClient(Binding binding, EndpointAddress address) : base(binding, address)
		{
		}

		public string ObtainAnswerToQuestion(string userQuestion)
		{
			return Channel.ObtainAnswerToQuestion(userQuestion);
		}
	}
}
