using api.Interface;
using api.Models.DTOs;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class EmailHelper: IEmailHelper
    {
        private readonly IConfiguration _config; 

        public EmailHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendEmailAddedUser(string username, string email, string name, string jwt)
        {
            var MailData = new MailData();
            MailData.EmailSubject = "Reset Password Email Marcatempo";
            MailData.EmailBody = $"User has been created with username: {username}. <br> Please reset your password :<a href=\"{_config["Client:url"]}/en/reset-password?email={email}&token={jwt}\">reset password page</a>";
            MailData.EmailToName = name;
            MailData.EmailToId = email;
            return await SendMail(MailData);
        }

        public async Task<bool> SendEmailResetPswd(string email, string name, string jwt)
        {
            var MailData = new MailData();
            MailData.EmailSubject = "Reset Password Email Marcatempo";
            MailData.EmailBody = $"For reset password go to link :<a href=\"{_config["Client:url"]}/en/reset-password?email={email}&token={jwt}\">reset password page</a>";
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
                    MailboxAddress emailFrom = new MailboxAddress(_config["MailSettings:SenderName"], _config["MailSettings:SenderEmail"]);
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
                        await mailClient.ConnectAsync(_config["MailSettings:Server"], int.Parse(_config["MailSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_config["MailSettings:Username"], _config["MailSettings:Password"]);
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
