using FcisArchiveBlazor.Settings;
using FCISQuestionsHub.Core.Models;
using Humanizer;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FcisArchiveBlazor.Services
{
    public class MaillingService : IMaillingService
    {

        private readonly ILogger<MaillingService> _logger;
        private readonly AuthenticationStateProvider  _getAuthenticationStateAsync;
    


        private readonly MailSettings _mailSettings;
        public MaillingService(IOptions<MailSettings> mailSettings, ILogger<MaillingService> logger, AuthenticationStateProvider getAuthenticationStateAsync)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
            _getAuthenticationStateAsync = getAuthenticationStateAsync;
            // _signInManager = signInManager;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, List<IFormFile> attachments = null)
        {
            var userName = "[Anonymous]";

            try
            {
                var user = await  _getAuthenticationStateAsync.GetAuthenticationStateAsync();
                if (user.User is not null) userName = user.User.Identity.Name;
            }
            catch (Exception e)
            {
                _logger.LogError(message: e.Message + $" #### {e.StackTrace} #### {e.Source} 1#### {e.InnerException?.Message}");
            }

            try
            {

                var email = new MimeMessage()
                {
                    Sender = MailboxAddress.Parse(_mailSettings.Email),
                    Subject = subject
                };
                email.To.Add(MailboxAddress.Parse(toEmail));

                var builder = new BodyBuilder();

                if (attachments is not null)
                {
                    byte[] fileBytes;
                    foreach (var file in attachments)
                    {
                        if (file.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        else
                        {
                            fileBytes = new byte[0];
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception e)
            {
                _logger.LogError(message: e.Message + $" #### {e.StackTrace} #### {e.Source} 1#### {e.InnerException?.Message} #### {userName}");
                return false;
            }
            return true;

        }

    }
}
