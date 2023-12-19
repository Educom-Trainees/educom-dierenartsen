using System;
using System.Threading.Tasks;
using BackendASP;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/email")]
public class EmailTestController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailTestController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("sendTestEmail")]
    public async Task<IActionResult> SendTestEmail()
    {
        try
        {
            // Replace these values with your actual test email details
            string toEmail = "corbijn.bulsink@hotmail.com";
            string subject = "Test Subject";
            string body = "This is a test email body.";

            await _emailService.SendEmailAsync(toEmail, subject, body);

            return Ok("Test email sent successfully.");
        } 
        catch (Exception ex)
        {
            return StatusCode(500, $"Error sending test email: {ex.Message}");
        }
    }
}
