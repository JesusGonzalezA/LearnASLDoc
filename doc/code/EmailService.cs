public interface IEmailService
{
    Task SendEmailConfirmationEmail(string email, string token);
    Task SendPasswordRecoveryEmail(string email, string token);
}

// Link sent for password recovery
string link = $"{_frontendOptions.Host}/auth/password-recovery/{email}/{token}";
string linkHtml = $"<a href=\"{link}\">here</a>";

// Link sent for email confirmation
string link = $"{_frontendOptions.Host}/auth/email-confirmation/{email}/{token}";
string linkHtml = $"<a target=\"_blank\" href=\"{link}\">here</a>";