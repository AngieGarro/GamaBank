using POJOS_DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore_Logic.Managers
{
    public class EmailManager
    {
        public void SendEmail(Customer c, Account a)
        {
            string OTP = generateOtp();
            var subject = "Welcome to GaMa Bank:" + " " + c.Name + " " + " " + "Verify user:";
            var body = "Please verify user, enter OTP code, Your token is: " + OTP;

            if (c.Email != null)
                PushEmail(c.Email, c.Name, subject, body).Wait();
            else
                throw new Exception("Email cannot Null");
        }

        private async Task PushEmail(string _email, string subjectText,string body,string name)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("agarrom@ucenfotec.ac.cr", "Fintech GaMa Bank");
            var subject = subjectText;
            var to = new EmailAddress(_email,name);
            var htmlContent = "<strong>" + body + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
            var response =  client.SendEmailAsync(msg);
        }

        public string generateOtp()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString();
        }
    }
}
