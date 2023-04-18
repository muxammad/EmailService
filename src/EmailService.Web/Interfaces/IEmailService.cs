using EmailService.Web.Models;

namespace EmailService.Web.Interfaces
{
    public interface IEmailService
    {
        public Task SendASync(EmailMessage emailMessage);
    }
}
