﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Services.Iplementation
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<AppSettings> options;
        private readonly ILogger<EmailService> logger;

        public EmailService(IOptions<AppSettings> options, ILogger<EmailService> logger)
        {
            this.options = options;
            this.logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var smtp = options.Value.SmtpConfiguration;
                var mailMessage = new MailMessage(new MailAddress(smtp.UserName, smtp.FromName),
                    new MailAddress(email));

                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;

                using var smtpClient = new SmtpClient(smtp.Server, smtp.PortNumber)
                {
                    Credentials = new NetworkCredential(smtp.UserName, smtp.Password),
                    EnableSsl = smtp.EnableSsl
                };

                await smtpClient.SendMailAsync(mailMessage);

                logger.LogInformation("Se envió correctamente el correo a {email}", email);
            }
            catch (SmtpException ex)
            {
                logger.LogWarning(ex, "No se puede enviar el correo {message}", ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Error al enviar el correo a {email} {message}", email, ex.Message);
            }
        }
    }
}
