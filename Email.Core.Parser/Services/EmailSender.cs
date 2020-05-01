using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Email.Core.Parser.Services
{
    public class EmailSender : IDisposable
    {
        public void Dispose()
        {
            
        }

        public async Task<SendGrid.Response> SendEmail(SendGridMessage message, string apiKey)
        {
            var client = new SendGridClient(apiKey);
            return await client.SendEmailAsync(message);
        }
    }
}
