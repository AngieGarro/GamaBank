using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmailSendGrid
{
    internal class Program
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("agarrom@ucenfotec.ac.cr", "Example test Email");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("angiegm5565@gmail.com", "Angie Garro");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
