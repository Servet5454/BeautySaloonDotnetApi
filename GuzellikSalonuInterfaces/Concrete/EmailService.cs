using GuzellikSalonuInterfaces.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace GuzellikSalonuInterfaces.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string from, string displayname, string to, string subject, string body, bool isBodyHtml = false)
        {
          await SendEmailAsync(from, displayname,new[] {to}, subject, body, isBodyHtml);
        }

        public async Task SendEmailAsync(string from, string displayname, string[] tos, string subject, string body, bool isBodyHtml = false)
        {
            try
            {
                SmtpClient client = new();
                MailMessage mail = new();

                client.Credentials = new NetworkCredential("halicarnassus33@gmail.com", "kkbtgpjxqihsqxfl");
                client.Port = 587;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.UseDefaultCredentials = true;


                mail.IsBodyHtml = isBodyHtml;
                foreach (var to in tos)
                {
                    mail.To.Add(to);
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.From = new(from, displayname, System.Text.Encoding.UTF8);

                await client.SendMailAsync(mail);


            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }



        }
    }
}
