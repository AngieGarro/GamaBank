using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TestSMSTwilio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "AC344e3259656e06d3891277541467023b";
            string authToken = "7b70cf6c1de5d8382e1f43af15585dde";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Test from C#",
                from: new Twilio.Types.PhoneNumber("+12184026808"),
                to: new Twilio.Types.PhoneNumber("+50664788712")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
