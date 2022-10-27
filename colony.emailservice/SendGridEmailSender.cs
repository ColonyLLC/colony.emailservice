// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace colony.emailservice
{
    public class SendGridEmailSender
    {
        private string _apikey;
        private string _fromaddress;
        private string _fromname;
        public SendGridEmailSender(string apikey, string fromaddress, string fromname)
        {
            _apikey = apikey;
            _fromaddress = fromaddress;
            _fromname = fromname;
        }

        public async Task<bool> SendEmail(string toAddress, string toName, string emailSubject, string emailPlainTextContent, string emailHtmlContent)
        {
            var client = new SendGridClient(_apikey);
            var from = new EmailAddress(_fromaddress, _fromname);
            var subject = emailSubject;
            var to = new EmailAddress(toAddress, toName);
            var plainTextContent = emailPlainTextContent;
            var htmlContent = emailHtmlContent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SendTestEmail()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
            var response = await client.SendEmailAsync(msg);

            return true;
        }
    }
}
