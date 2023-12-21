using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace BackendASP
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task SendAppointmentConfirmationEmailAsync(AppointmentDTO appointmentDTO);
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
        public async Task SendAppointmentConfirmationEmailAsync(AppointmentDTO appointmentDTO)
        {
            try
            {
                // Replace these values with your actual email details
                string toEmail = "test@hotmail.com"; // Use the email address of the customer
                string subject = $"Afspraak bevestiging voor {appointmentDTO.Date}";
                string body = $@"
                Beste {appointmentDTO.CustomerName},
                <br />
                <br />
                Bij deze bevestigen wij dat uw afspraak gepland is voor:
                <br />
                <br />
                Datum: {appointmentDTO.Date}
                <br />
                Tijd: {appointmentDTO.TimeSlotTime}
                <br />
                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}
                <br />
                <br />
                We kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.
                <br />
                <br />
                Tot ziens in de praktijk!
                <br />
                <br />
                Met vriendelijke groeten,
                <br />
                <br />
                Karel en Danique van Dierenpraktijk HappyPaws
                ";

                // Send the confirmation email
                await SendEmailAsync(toEmail, subject, body);
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or throw as needed)
                Console.WriteLine($"Error sending appointment confirmation email: {ex.Message}");
            }
        }
    }
}
