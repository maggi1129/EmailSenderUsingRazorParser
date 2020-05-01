using Email.Core.Parser;
using Email.Core.Parser.Models;
using Email.Core.Parser.Services;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace EmailSenderUsingRazorParser
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            using (RazorParserService parser = new RazorParserService())
            {
                var emailBody = parser.Parse("HelloHowdyLetsMeet",
                new HelloHowdyModel("Times Square","Guest", "ABC"));

                var message = new SendGridMessage();

                //Set the to/from and subject using the below 
                //message.AddTos(<to list>) or 
                //message.SetFrom(<from email id>);
                //message.SetSubject(<email subject>);

             
                message.AddContent("text/html", emailBody);

                //Set the sendgrid apikey here
                string apiKey = "";

                using (var sender = new EmailSender())
                {
                    await sender.SendEmail(message, apiKey);
                }
            }
        }
    }
}
