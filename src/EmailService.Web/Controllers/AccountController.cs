using EmailService.Web.Interfaces;
using EmailService.Web.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController
    {
        private readonly IEmailService emailService;
        public AccountController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost("Message")]
        public async Task SendAsync(EmailMessage message)
        {
            for (int i = 0;i<10;i++)
            {
                await this.emailService.SendASync(message);
            }
        }
    }
}
