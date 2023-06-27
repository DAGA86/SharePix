using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace SharePix.Shared.Providers
{
    public class SendEmailProvider
    {
        private readonly IConfiguration _Configuration;
        public SendEmailProvider(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void Send(string toName, string toAddress, string subject, string content)
        {
            // Configure your email service or library to send the email
            // Include a link with the token in the email's content

            // For example, using the MailKit library:
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_Configuration.GetValue<string>("EmailSettings:FromName"), _Configuration.GetValue<string>("EmailSettings:FromAddress")));
            message.To.Add(new MailboxAddress(toName, toAddress));
            message.Subject = subject;

            // Compose the email body
            var builder = new BodyBuilder();
            builder.HtmlBody = content;
            message.Body = builder.ToMessageBody();

            // Use your email service's or library's API to send the email
            // For example, using the MailKit library:

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(_Configuration.GetValue<string>("EmailSettings:Domain"), _Configuration.GetValue<int>("EmailSettings:Port"), true);
                client.AuthenticationMechanisms.Remove(_Configuration.GetValue<string>("EmailSettings:Authentication"));
                client.Authenticate(_Configuration.GetValue<string>("EmailSettings:FromAddress"), _Configuration.GetValue<string>("EmailSettings:Password"));
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
