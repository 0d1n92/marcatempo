using api.Interface;
using api.Models.Data;
using api.Models.DTOs;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class EmailHelper: IEmailHelper
    {
        private readonly IConfiguration _config;

        private readonly SmtpConfig _smtp;

        private readonly DataContext _context;

        public EmailHelper(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
            var jsonString = context.Configuration.First(conf => conf.Category == "mail").Value;

            _smtp = JsonConvert.DeserializeObject<SmtpConfig>(jsonString.ToString());
        }

        public async Task<bool> SendEmailAddedUser(string username, string email, string name, string jwt)
        {
            var MailData = new MailData();
            MailData.EmailSubject = $"Benvenuto {username} crea la tua password";
            MailData.EmailBody = MailData.EmailBody =$@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f5f5f5;
            }}
            .container {{
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
                background-color: #ffffff;
                border-radius: 10px;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            }}
            .button {{
                display: inline-block;
                padding: 10px 20px;
                background-color: #007bff;
                color: #ffffff;
                text-decoration: none;
                border-radius: 5px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Benvenuto in marcatempo {username}</h1><br>
            <p>Clicca il pulsante <b>Imposta password</b> per impostare la tua chiave di accesso:</p><br>
             <a class='button' href=""{Environment.GetEnvironmentVariable("CLIENT_URL")}/it/reset-password?email={email}&token={jwt}"">Imposta password</a>
        </div>
    </body>
    </html>";

            MailData.EmailToName = name;
            MailData.EmailToId = email;
            return await SendMail(MailData);
        }

        public async Task<bool> SendEmailResetPswd(string email, string name, string jwt)
        {
            var MailData = new MailData();
            MailData.EmailSubject = "Reset Password Email Marcatempo";
            MailData.EmailBody = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f5f5f5;
            }}
            .container {{
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
                background-color: #ffffff;
                border-radius: 10px;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            }}
            .button {{
                display: inline-block;
                padding: 10px 20px;
                background-color: #007bff;
                color: #ffffff;
                text-decoration: none;
                border-radius: 5px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Ciao {name}</h1><br>
            <p>E' stata richiesta la procedura di cambio password nel tuo marcatempo.<br> Se sei stato tu clicca <b>Reimposta password<b></p><br>
            <a class='button' href=""{Environment.GetEnvironmentVariable("CLIENT_URL")}/it/reset-password?email={email}&token={jwt}"">Reimposta password</a>
        </div>
    </body>
    </html>";

            MailData.EmailToName = name;
            MailData.EmailToId = email;
            return await SendMail(MailData);

        }

        public async Task <bool>SendEmailBlockedUser(string username, string email, string name)
        {
            var MailData = new MailData();
            MailData.EmailSubject = "Blocked user, please reset your password Email Marcatempo";
            MailData.EmailBody = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f5f5f5;
            }}
            .container {{
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
                background-color: #ffffff;
                border-radius: 10px;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            }}
            .button {{
                display: inline-block;
                padding: 10px 20px;
                background-color: #007bff;
                color: #ffffff;
                text-decoration: none;
                border-radius: 5px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Ciao {name}</h1><br>
            <p>Ti informiamo che il tuo account marcatempo è stato bloccato a causa di numerosi tentativi di accesso errati. Per motivi di sicurezza, l'accesso è stato temporaneamente disabilitato.</p><br>
            <p>Per sbloccare il tuo account clicca su <b>Reimposta password<b></P>
            <a class='button' href=""{Environment.GetEnvironmentVariable("CLIENT_URL")}/it/password-forgot"">Reimposta password</a>
        </div>
    </body>
    </html>";
            //MailData.EmailBody = $"We have blocked user accounts for maximum number of attempts, please reset your password :<a href=\"{Environment.GetEnvironmentVariable("CLIENT_URL")}/it/password-forgot\">reset password page</a>";
            MailData.EmailToName = name;
            MailData.EmailToId = email;
            return await SendMail(MailData);
        }
        private  async Task<bool> SendMail(MailData mailData)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_smtp.SenderName, _smtp.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);


                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = mailData.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync(_smtp.Server, _smtp.Port, MailKit.Security.SecureSocketOptions.Auto);
                        await mailClient.AuthenticateAsync(_smtp.UserName, _smtp.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
               //to do: integrare sistema di log
                return false;
            }
        }
    }
}
