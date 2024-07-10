namespace CleanArchitecture.Infrastructure.EmailSender;

using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using CleanArchitecture.Application.Models.EmailSender;
using CleanArchitecture.Application.Contracts.Infrastructure.EmailSender;

public class EmailSender : IEmailSender
{
    private EmailSettings _emailSettings { get; }
    public EmailSender(IOptions<EmailSettings> emailSettingsOptions)
    {
        _emailSettings = emailSettingsOptions.Value;
    }
    public async Task<bool> SendEmail(EmailMessage emailMessage)
    {
        var sendGridClient = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(emailMessage.To);
        var from = new EmailAddress { Email = _emailSettings.FromAddress, Name = _emailSettings.FromName };
        var message = MailHelper.CreateSingleEmail(from, to, emailMessage.Subject, emailMessage.Body, emailMessage.Body);
        var response = await sendGridClient.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}
