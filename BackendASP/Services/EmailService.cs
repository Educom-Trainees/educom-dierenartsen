using BackendASP.Database;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace BackendASP.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task FormatAndSendEmailAsync<T>(int emailTemplateId, T dto);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly PetCareContext _context;

        public EmailService(IConfiguration configuration, PetCareContext petCareContext)
        {
            _configuration = configuration;
            _context = petCareContext;
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

        public async Task<(string subject, string body, EmailTypes emailType)> GetEmailTemplateAsync(int emailTemplateId)
        {
            var template = await _context.EmailTemplates
                .Where(t => t.Id == emailTemplateId)
                .FirstOrDefaultAsync();
            if (template != null)
            {
                return (template.Subject ?? string.Empty, template.Body ?? string.Empty, template.EmailType);
            }
            else
            {
                return (string.Empty, string.Empty, EmailTypes.USER);
            }
        }

        public async Task FormatAndSendEmailAsync<T>(int emailTemplateId, T dto)
        {
            try
            {
                string toEmail = "test@hotmail.com"; // Use the email address of the customer

                var (subject, body, emailType) = await GetEmailTemplateAsync(emailTemplateId);

                if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
                {
                    throw new InvalidOperationException("Subject or body is empty.");
                }

                if (dto is UserDTO userDTO && emailType == EmailTypes.USER)
                {
                    ReplacePlaceholders(ref subject, userDTO);
                    ReplacePlaceholders(ref body, userDTO);
                }
                else if (dto is AppointmentDTO appointmentDTO && emailType == EmailTypes.APPOINTMENT)
                {
                    ReplacePlaceholders(ref subject, appointmentDTO);
                    ReplacePlaceholders(ref body, appointmentDTO);
                }
                body = body.Replace("\n", "<br>");

                // Send the confirmation email
                await SendEmailAsync(toEmail, subject, body);
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or throw as needed)
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

        private static void ReplacePlaceholders<T>(ref string text, T dto)
        {
            if (dto is UserDTO userDTO)
            {
                text = text.Replace("{Naam klant}", $"{userDTO.FirstName} {userDTO.LastName}");
                text = text.Replace("{Telefoonnummer}", userDTO.PhoneNumber);
                text = text.Replace("{Email}", userDTO.Email);
            }

            if (dto is AppointmentDTO appointmentDTO)
            {
                text = text.Replace("{Naam klant}", $"{appointmentDTO.CustomerName}");
                text = text.Replace("{Telefoonnummer}", appointmentDTO.PhoneNumber);
                text = text.Replace("{Email}", appointmentDTO.Email);
                text = text.Replace("{Datum}", appointmentDTO.Date.ToString());
                text = text.Replace("{Tijdslot}", appointmentDTO.TimeSlotTime);
                text = text.Replace("{Duur}", appointmentDTO.Duration.ToString() + " minuten");
                text = text.Replace("{Dierenarts}", appointmentDTO.Doctor.ToFriendlyString());
            }
        }

    }
}
