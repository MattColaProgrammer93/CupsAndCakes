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
        
    }
}
