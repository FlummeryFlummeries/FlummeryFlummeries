using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerce_App.Models.Services
{
    public class EmailService : IEmail
    {
        private IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// Construct and send an Email with SendGrid
        /// </summary>
        /// <param name="emailAddress">Email address to be sent to</param>
        /// <param name="subject">Subject of the email</param>
        /// <param name="htmlMessage">HTML Content of the email</param>
        /// <returns>Task of completion for email sending</returns>
        public async Task SendEmail(string templateId, List<Personalization> personalizations, string subject = null, string message = null)
        {
            SendGridClient client = new SendGridClient(_config["SENDGRID_API_KEY"]);

            SendGridMessage email = new SendGridMessage()
            {
                From = new EmailAddress("Flummery@Flummeries.com", "Flummery Flummeries"),
                TemplateId = templateId,
                Personalizations = personalizations
            };
            Response result = await client.SendEmailAsync(email);

        }
    }
}
