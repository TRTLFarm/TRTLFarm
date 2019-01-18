using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TRTLFarm.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential(ConfigurationManager.AppSetting["EmailAccount"].ToString(), ConfigurationManager.AppSetting["EmailPassword"].ToString())
            };
            using (var message = new MailMessage("admin@trtlfarm.com", email)
            {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }

    }
}
