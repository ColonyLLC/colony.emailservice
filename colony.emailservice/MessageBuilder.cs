using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace colony.emailservice
{
    public class MessageBuilder
    {
        public MailMessage BuildMessage(string[] toaddresses,
            string fromaddress,
            string fromdisplayname,
            string subject,
            string body)
        {
            MailMessage mm = new MailMessage();
            foreach (string toaddress in toaddresses)
            {
                mm.To.Add(new MailAddress(toaddress));
            }
            mm.From = new MailAddress(fromaddress , string.IsNullOrEmpty(fromdisplayname) ? fromaddress : fromdisplayname);
            mm.Subject = subject;
            mm.Body = body;
            
            //mm.AlternateViews
            //mm.Attachments
            //mm.Bcc
            //mm.BodyTransferEncoding
            //mm.BodyEncoding
            //mm.CC
            //mm.DeliveryNotificationOptions
            //mm.Headers
            //mm.HeadersEncoding
            //mm.IsBodyHtml
            //mm.Priority
            //mm.ReplyTo
            //mm.ReplyToList
            //mm.Sender
            //mm.SubjectEncoding



            return mm;

        }
    }
}
