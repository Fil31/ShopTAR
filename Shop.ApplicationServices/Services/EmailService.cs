﻿using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Microsoft.Extensions.Configuration;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace Shop.ApplicationServices.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _config;

        public EmailServices(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto req)
        {
            var email = new MimeMessage();

            var host_ = _config.GetSection("EmailHost").Value;
            var username_ = _config.GetSection("EmailUsername").Value;
            var password_ = _config.GetSection("EmailPassword").Value;

            email.From.Add(MailboxAddress.Parse(username_));
            email.To.Add(MailboxAddress.Parse(req.To));

            email.Subject = req.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = req.Body
            };

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(host_, 587, SecureSocketOptions.StartTls);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate(username_, password_);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}