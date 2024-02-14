using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AppCore_Logic.Managers
{
    public class SmsManager
    {
        public void SendSMS(Transaction T, Customer c)
        {
            //Misma logica que el envio del correo.
            var msj = "Hola! " + c.Name + " Se ha realizado un moviento financiero en su cuenta, por favor revisar su cuenta.";
            PushSMS(c.Phone,msj);

        }

        private void PushSMS(string phoneNumber, string text)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "AC344e3259656e06d3891277541467023b";
            string authToken = "7b70cf6c1de5d8382e1f43af15585dde";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+12184026808"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );

        }
    }
}
