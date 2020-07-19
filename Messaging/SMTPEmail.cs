using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Messaging
{
    /// <summary>
    /// Sends SMTP emails
    /// </summary>
    public class SMTPEmail : ISendSMTP
    {
        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="sender"> Email address of sender </param>
        /// <param name="password"> Password for the sender </param>
        /// <param name="to"> Email addresses of recipients </param>
        /// <param name="subject"> Email subject </param>
        /// <param name="body"> Email body </param>
        public void Send(string sender, string password, IEnumerable<string> to, string subject, string body)
        {
            var message = GetMessage(sender, to, subject, body);

            using var client = GetClient(sender, password);
            client.Send(message);
        }

        /// <summary>
        /// Asynchronously send an email
        /// </summary>
        /// <param name="sender"> Email address of sender </param>
        /// <param name="password"> Password for the sender </param>
        /// <param name="to"> Email addresses of recipients </param>
        /// <param name="subject"> Email subject </param>
        /// <param name="body"> Email body </param>
        /// <returns> A task </returns>
        public async Task SendAsync(string sender, string password, IEnumerable<string> to, string subject, string body)
        {
            var message = GetMessage(sender, to, subject, body);

            using var client = GetClient(sender, password);
            await client.SendMailAsync(message);
        }

        /// <summary>
        /// Create a MailMessage
        /// </summary>
        /// <param name="sender"> Email sender's address </param>
        /// <param name="to"> Email recipients' addresses </param>
        /// <param name="subject"> Email subject </param>
        /// <param name="body"> Email body </param>
        /// <returns> A MailMessage </returns>
        private MailMessage GetMessage(string sender, IEnumerable<string> to, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(sender),
                Subject = subject,
                Body = body
            };

            foreach (var recipient in to)
            {
                message.To.Add(new MailAddress(recipient));
            }

            return message;
        }

        /// <summary>
        /// Create an SMTP client
        /// </summary>
        /// <param name="sender"> Email sender's address </param>
        /// <param name="password"> Email sender's password </param>
        /// <returns> An SMTPClient </returns>
        private SmtpClient GetClient(string sender, string password)
        {
            var client = new SmtpClient();

            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(sender, password);

            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.EnableSsl = true;

            return client;
        }
    }
}