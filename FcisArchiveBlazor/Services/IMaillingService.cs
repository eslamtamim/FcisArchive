namespace FcisArchiveBlazor.Services
{
    public interface IMaillingService
    {


        Task SendEmailAsync(string toEmail, string subject, string body, List<IFormFile> attachments = null);

    }
}
