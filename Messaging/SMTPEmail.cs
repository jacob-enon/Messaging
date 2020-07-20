using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BigJacob.Messaging
{
    /// <summary>
    /// Sends SMTP emails
    /// </summary>
    public class SMTPEmail : ISendSMTP, IDisposable
    {
        private readonly SmtpClient client;
        private readonly string fromAddress;

        public SMTPEmail(string fromAddress, string password)
        {
            this.fromAddress = fromAddress;

            client = fromAddress.Contains("gmail")
                ? new SmtpClient(Constants.GoogleHost, Constants.GooglePort)
                : new SmtpClient(Constants.OutlookHost, Constants.OutlookPort);

            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromAddress, password);
            client.EnableSsl = true;
        }

        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="toAddresses"> Email addresses of recipients </param>
        /// <param name="subject"> Email subject </param>
        /// <param name="body"> Email body </param>
        public void Send(IEnumerable<string> toAddresses, string subject, string body)
        {
            var message = GetMessage(toAddresses, subject, body);

            client.Send(message);
        }

        /// <summary>
        /// Asynchronously send an email
        /// </summary>
        /// <param name="toAddresses"> Email addresses of recipients </param>
        /// <param name="subject"> Email subject </param>
        /// <param name="body"> Email body </param>
        /// <returns> A task </returns>
        public async Task SendAsync(IEnumerable<string> toAddresses, string subject, string body)
        {
            var message = GetMessage(toAddresses, subject, body);

            await client.SendMailAsync(message);
        }

        /// <summary>
        /// Create a MailMessage
        /// </summary>
        /// <param name="toAddresses"> Email recipients' addresses </param>
        /// <param name="subject"> Email subject </param>
        /// <param name="body"> Email body </param>
        /// <returns> A MailMessage </returns>
        private MailMessage GetMessage(IEnumerable<string> toAddresses, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = body
            };

            foreach (var recipient in toAddresses)
            {
                message.To.Add(new MailAddress(recipient));
            }

            return message;
        }

        /// <summary>
        /// Dispose of the SMTP Client
        /// </summary>
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}