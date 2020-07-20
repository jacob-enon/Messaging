using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigJacob.Messaging
{
    /// <summary>
    /// Sends messages using SMTP
    /// </summary>
    public interface ISendSMTP
    {
        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="toAddresses"> Addresses of the recipients </param>
        /// <param name="subject"> Message subject </param>
        /// <param name="body"> Message body </param>
        void Send(IEnumerable<string> toAddresses, string subject, string body);

        /// <summary>
        /// Asynchronously send a message
        /// </summary>
        /// <param name="toAddresses"> Addresses of the recipients </param>
        /// <param name="subject"> Message subject </param>
        /// <param name="body"> Message body </param>
        /// <returns> A task </returns>
        Task SendAsync(IEnumerable<string> toAddresses, string subject, string body);
    }
}