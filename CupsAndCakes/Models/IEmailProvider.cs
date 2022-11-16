using SendGrid;
using SendGrid.Helpers.Mail;

namespace CupsAndCakes.Models
{
    public interface IEmailProvider
    {
        Task SendEmailAsync(string subject, string content);
    }

    public class EmailProviderSendGrid : IEmailProvider
    {
        private readonly IConfiguration _config;

        public EmailProviderSendGrid(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string subject, string content)
        {
            var apiKey = _config.GetSection("SendGridKey").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_config.GetSection("FromEmail").Value, "CupsAndCakes"),
                Subject = "Testing",
                PlainTextContent = "This is a test email"
            };
            msg.AddTo(new EmailAddress("mattchoque115@gmail.com", "Matthew Choque"));
            await client.SendEmailAsync(msg);
            // var response = await client SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
