namespace fsiplanner_backend.Repositories;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}
