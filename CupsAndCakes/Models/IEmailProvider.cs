using SendGrid;
using SendGrid.Helpers.Mail;

namespace CupsAndCakes.Models
{
    public interface IEmailProvider
    {
        Task SendEmailAsync(string toEmail, string fromEmail, string subject,
                                string content, string htmlContent);
    }

    public class EmailProviderSendGrid : IEmailProvider
    {
        private readonly IConfiguration _config;

        public EmailProviderSendGrid(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string fromEmail, string subject, string content, string htmlContent)
        {
            var apiKey = _config.GetSection("SendGridKey").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_config.GetSection("FromEmail").Value, "CupsAndCakes"),
                Subject = "Testing",
                PlainTextContent = "This is a test email",
                HtmlContent = "<strong>This is a test email</strong>"
            };
            msg.AddTo(new EmailAddress("mattchoque115@gmail.com", "Matthew Choque"));
            await client.SendEmailAsync(msg);
            // var response = await client SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
