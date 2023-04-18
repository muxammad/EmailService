using EmailService.Web.Interfaces;
using EmailService.Web.Models;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace EmailService.Web.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    public EmailService(IConfiguration configuration)
    {
        this._configuration = configuration.GetSection("Email");   
    }
    public async Task SendASync(EmailMessage emailMessage)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(this._configuration["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(emailMessage.To));
        email.Subject = emailMessage.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };

        var smpt = new SmtpClient();
        await smpt.ConnectAsync(this._configuration["Host"], 587, SecureSocketOptions.StartTls);
        await smpt.AuthenticateAsync(this._configuration["EmailAddress"], this._configuration["Password"]);
        await smpt.SendAsync(email);
        await smpt.DisconnectAsync(true);
    }
}
