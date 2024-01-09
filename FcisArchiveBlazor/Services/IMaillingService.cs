using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FcisArchiveBlazor.Services
{
    public interface IMaillingService 
    {


        Task<bool> SendEmailAsync(string toEmail, string subject, string body, List<IFormFile> attachments = null);

    }
}
