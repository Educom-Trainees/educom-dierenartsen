using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace BackendASP
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("EmailSettings");
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Dierenpraktijk HappyPaws", "no-reply.happypaws@hotmail.com"));
            emailMessage.To.Add(new MailboxAddress("Recipient", toEmail));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                string smtpServer = "localhost"; // smtp-mail.outlook.com Hotmail SMTP server
                int smtpPort = 25; // 587 Hotmail SMTP port
                string userName = "no-reply.happypaws@hotmail.com"; // Your Hotmail email address
                string password = "jDqFZ476xmti4T"; // Your Hotmail password

                await client.ConnectAsync(smtpServer, smtpPort /*SecureSocketOptions.StartTls*/);

                // Use your Hotmail email address and password for authentication
                await client.AuthenticateAsync(userName, password);

                // Send the email
                await client.SendAsync(emailMessage);

                // Disconnect from the server
                await client.DisconnectAsync(true);
            }
        }
    }
}
