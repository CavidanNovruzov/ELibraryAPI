using ELibraryAPI.Application.Abstractions.Services;
using ELibraryAPI.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp; // DƏYİŞİKLİK: System.Net.Mail əvəzinə bu olmalıdır
using MailKit.Security; // SecureSocketOptions üçün lazımdır
using Microsoft.Extensions.Logging;


namespace ELibraryAPI.Infrastructure.Services;

public class SmtpEmailSender : IEmailSender
{
    private readonly SmtpOptions _options;
    private readonly ILogger<SmtpEmailSender> _logger;

    public SmtpEmailSender(IOptions<SmtpOptions> options, ILogger<SmtpEmailSender> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task SendEmailAsync(
        string to,
        string subject,
        string htmlBody,
        string? plainBody = null,
        CancellationToken ct = default)
    {
        // 1. Kill-Switch (Diagnostic Check)
        if (!_options.SendEmails)
        {
            _logger.LogWarning("Email göndərilməsi tənzimləmələrdə (Options) söndürülüb.");
            return;
        }

        if (string.IsNullOrWhiteSpace(to))
        {
            _logger.LogError("Email göndərilə bilmədi: Alıcı ünvanı boşdur.");
            return;
        }

        var message = CreateMimeMessage(to, subject, htmlBody, plainBody);

        using var client = new SmtpClient();

        try
        {
            _logger.LogInformation("{To} ünvanına email göndərilir...", to);

            // 2. Müasir Bağlantı (Timeout daxil)
            client.Timeout = 10000;
            var secureSocket = _options.UseSsl ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls;

            await client.ConnectAsync(_options.SmtpHost, _options.SmtpPort, secureSocket, ct);

            if (!string.IsNullOrWhiteSpace(_options.UserName))
            {
                await client.AuthenticateAsync(_options.UserName, _options.Password, ct);
            }

            await client.SendAsync(message, ct);

            _logger.LogInformation("Email uğurla göndərildi: {To}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{To} ünvanına email göndərilərkən xəta: {Message}", to, ex.Message);
            throw; // Xətanı throw edirik ki, çağıran tərəf (məs: Background Job) xəbərdar olsun
        }
        finally
        {
            if (client.IsConnected)
                await client.DisconnectAsync(true, ct);
        }
    }

    private MimeMessage CreateMimeMessage(string to, string subject, string htmlBody, string? plainBody)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_options.FromName, _options.FromEmail));
        message.To.Add(MailboxAddress.Parse(to.Trim()));
        message.Subject = subject;

        // 3. Multipart Body (Best Practice)
        // Həm HTML, həm də PlainText əlavə etmək email-in SPAM-a düşmə riskini azaldır
        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = htmlBody,
            TextBody = plainBody ?? string.Empty
        };

        message.Body = bodyBuilder.ToMessageBody();
        return message;
    }
}