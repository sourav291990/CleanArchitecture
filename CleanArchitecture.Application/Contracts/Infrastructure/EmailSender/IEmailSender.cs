using CleanArchitecture.Application.Models.EmailSender;

namespace CleanArchitecture.Application.Contracts.Infrastructure.EmailSender;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage emailMessage);
}
