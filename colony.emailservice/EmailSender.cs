using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace colony.emailservice
{
    public class EmailSender
    {
        private SmtpClient smtp;
        private EmailConfig config;
        public EmailSender(EmailConfig emailConfig)
        {
            config = emailConfig;
        }
        public async Task SendMailAsync(MailMessage mailMessage)
        {
            try
            {
                using (smtp = new SmtpClient(config.SmtpServer, config.Port))
                {
                    if (config.UserName != "")
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(config.UserName, config.Password);
                    }

                    smtp.EnableSsl = config.SSL;
                    await smtp.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SendMail(MailMessage mailMessage)
        {
            try
            {
                using (smtp = new SmtpClient(config.SmtpServer, config.Port))
                {
                    if (config.UserName != "")
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(config.UserName, config.Password);
                    }

                    smtp.EnableSsl = config.SSL;
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
