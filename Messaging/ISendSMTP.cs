using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messaging
{
    /// <summary>
    /// Sends messages using SMTP
    /// </summary>
    public interface ISendSMTP
    {
        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="sender"> Address of the sender </param>
        /// <param name="password"> Password of the sender </param>
        /// <param name="to"> Addresses of the recipients </param>
        /// <param name="subject"> Message subject </param>
        /// <param name="body"> Message body </param>
        void Send(string sender, string password, IEnumerable<string> to, string subject, string body);

        /// <summary>
        /// Asynchronously send a message
        /// </summary>
        /// <param name="sender"> Address of the sender </param>
        /// <param name="password"> Password of the sender </param>
        /// <param name="to"> Addresses of the recipients </param>
        /// <param name="subject"> Message subject </param>
        /// <param name="body"> Message body </param>
        /// <returns> A task </returns>
        Task SendAsync(string sender, string password, IEnumerable<string> to, string subject, string body);
    }
}