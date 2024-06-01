using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using WildOasis.Application.Common.Interfaces;

namespace WildOasis.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _fromEmail;


    public EmailService(IConfiguration configuration)
    {
        var smtpSection = configuration.GetSection("Smtp");
        _smtpClient = new SmtpClient
        {
            Host = smtpSection["Host"],
            Port = int.Parse(smtpSection["Port"]),
            EnableSsl = bool.Parse(smtpSection["EnableSsl"]),
            Credentials = new NetworkCredential(smtpSection["Username"], smtpSection["Password"])
        };
        Console.Write(_smtpClient);
        _fromEmail = smtpSection["Username"];
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_fromEmail),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        mailMessage.To.Add(to);

        await _smtpClient.SendMailAsync(mailMessage);
    }
}