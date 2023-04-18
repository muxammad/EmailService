using EmailService.Web.Interfaces;
using EmailService.Web.Models;

namespace EmailService.Web.Services;

public class EmailService : IEmailService
{
    public Task SendASync(EmailMessage emailMessage)
    {
        throw new NotImplementedException();
    }
}
