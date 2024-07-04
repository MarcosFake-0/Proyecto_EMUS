using Microsoft.AspNetCore.Identity.UI.Services;

namespace Proyecto_EMUS.Utilities
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //implementar el sistema para envio de correos

            return Task.CompletedTask;
        }
    }
}
