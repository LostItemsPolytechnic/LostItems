using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace LostItems.API.TemporaryAuthModels
{
    public class DummyEmailSender : IEmailSender<ApplicationUser>, IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage) { return Task.CompletedTask; }
        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) { return Task.CompletedTask; }
        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) { return Task.CompletedTask; }
        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) { return Task.CompletedTask; }
    }
}