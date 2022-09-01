using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using ServiceLogger.Abstracts;

namespace ServiceLogger.Concretes
{
    public class EmailService : IEmailService
    {
        public async Task CreateEmailAsync()
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(Configuration.EmailUsername));
            email.To.Add(MailboxAddress.Parse(Configuration.EmailUsernameToSend));
            email.Subject = "Çalışmayan Servis Hk.";
            email.Body = new TextPart(TextFormat.Html) { Text = $"Servis hatası! {DateTime.Now}<br>Lütfen en kısa sürede mevcut servisi kontrol ediniz."};
            await SendEmail(email);
        }
        private async Task SendEmail(MimeMessage email)
        {
            using SmtpClient smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(Configuration.HotmailHost, int.Parse(Configuration.HotmailPort), SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(Configuration.EmailUsername, Configuration.EmailPassword);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
