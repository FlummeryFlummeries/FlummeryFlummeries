using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface IEmail
    {
        /// <summary>
        /// Construct and send an Email with SendGrid
        /// </summary>
        /// <param name="emailAddress">Email address to be sent to</param>
        /// <param name="subject">Subject of the email</param>
        /// <param name="htmlMessage">HTML Content of the email</param>
        /// <returns>Task of completion for email sending</returns>
        Task SendEmail(string emailAddress, string subject, string htmlMessage);
    }
}
