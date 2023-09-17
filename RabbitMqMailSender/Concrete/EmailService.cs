using RabbitMqMailSenderWorkerService.Abstract;
using RabbitMqMailSenderWorkerService.EmailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using MimeKit;
using MailKit.Security;

namespace RabbitMqMailSenderWorkerService.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly EmailSettings _settings;


        public EmailService(IConfiguration configuration, EmailSettings settings)
        {
            _configuration = configuration;
            _settings = settings;
        }

        public async Task<string> GetHtmlContentAsync()
        {
            string? response = "<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\r\n  <meta name=\"x-apple-disable-message-reformatting\">\r\n  <title></title>\r\n  <!--[if mso]>\r\n  <noscript>\r\n    <xml>\r\n      <o:OfficeDocumentSettings>\r\n        <o:PixelsPerInch>96</o:PixelsPerInch>\r\n      </o:OfficeDocumentSettings>\r\n    </xml>\r\n  </noscript>\r\n  <![endif]-->\r\n  <style>\r\n    table, td, div, h1, p {font-family: Arial, sans-serif;}\r\n  </style>\r\n</head>\r\n<body style=\"margin:0;padding:0;\">\r\n  <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;\">\r\n    <tr>\r\n      <td align=\"center\" style=\"padding:0;\">\r\n        <table role=\"presentation\" style=\"width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;\">\r\n          <tr>\r\n            <td align=\"center\" style=\"padding:40px 0 30px 0;background:#70bbd9;\">\r\n              <img src=\"https://assets.codepen.io/210284/h1.png\" alt=\"\" width=\"300\" style=\"height:auto;display:block;\" />\r\n            </td>\r\n          </tr>\r\n          <tr>\r\n            <td style=\"padding:36px 30px 42px 30px;\">\r\n              <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;\">\r\n                <tr>\r\n                  <td style=\"padding:0 0 36px 0;color:#153643;\">\r\n                    <h1 style=\"font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;\">Email Servet ZABUN</h1>\r\n                    <p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus adipiscing felis, sit amet blandit ipsum volutpat sed. Morbi porttitor, eget accumsan et dictum, nisi libero ultricies ipsum, posuere neque at erat.</p>\r\n                    <p style=\"margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\"><a href=\"http://www.example.com\" style=\"color:#ee4c50;text-decoration:underline;\">In tempus felis blandit</a></p>\r\n                  </td>\r\n                </tr>\r\n                <tr>\r\n                  <td style=\"padding:0;\">\r\n                    <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;\">\r\n                      <tr>\r\n                        <td style=\"width:260px;padding:0;vertical-align:top;color:#153643;\">\r\n                          <p style=\"margin:0 0 25px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\"><img src=\"https://assets.codepen.io/210284/left.gif\" alt=\"\" width=\"260\" style=\"height:auto;display:block;\" /></p>\r\n                          <p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus adipiscing felis, sit amet blandit ipsum volutpat sed. Morbi porttitor, eget accumsan dictum, est nisi libero ultricies ipsum, in posuere mauris neque at erat.</p>\r\n                          <p style=\"margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\"><a href=\"http://www.example.com\" style=\"color:#ee4c50;text-decoration:underline;\">Blandit ipsum volutpat sed</a></p>\r\n                        </td>\r\n                        <td style=\"width:20px;padding:0;font-size:0;line-height:0;\">&nbsp;</td>\r\n                        <td style=\"width:260px;padding:0;vertical-align:top;color:#153643;\">\r\n                          <p style=\"margin:0 0 25px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\"><img src=\"https://assets.codepen.io/210284/right.gif\" alt=\"\" width=\"260\" style=\"height:auto;display:block;\" /></p>\r\n                          <p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Morbi porttitor, eget est accumsan dictum, nisi libero ultricies ipsum, in posuere mauris neque at erat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus adipiscing felis, sit amet blandit ipsum volutpat sed.</p>\r\n                          <p style=\"margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\"><a href=\"http://www.example.com\" style=\"color:#ee4c50;text-decoration:underline;\">In tempus felis blandit</a></p>\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n                  </td>\r\n                </tr>\r\n              </table>\r\n            </td>\r\n          </tr>\r\n          <tr>\r\n            <td style=\"padding:30px;background:#ee4c50;\">\r\n              <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;\">\r\n                <tr>\r\n                  <td style=\"padding:0;width:50%;\" align=\"left\">\r\n                    <p style=\"margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#ffffff;\">\r\n                      &reg; Someone, Somewhere 2021<br/><a href=\"http://www.example.com\" style=\"color:#ffffff;text-decoration:underline;\">Unsubscribe</a>\r\n                    </p>\r\n                  </td>\r\n                  <td style=\"padding:0;width:50%;\" align=\"right\">\r\n                    <table role=\"presentation\" style=\"border-collapse:collapse;border:0;border-spacing:0;\">\r\n                      <tr>\r\n                        <td style=\"padding:0 0 0 10px;width:38px;\">\r\n                          <a href=\"http://www.twitter.com/\" style=\"color:#ffffff;\"><img src=\"https://assets.codepen.io/210284/tw_1.png\" alt=\"Twitter\" width=\"38\" style=\"height:auto;display:block;border:0;\" /></a>\r\n                        </td>\r\n                        <td style=\"padding:0 0 0 10px;width:38px;\">\r\n                          <a href=\"http://www.facebook.com/\" style=\"color:#ffffff;\"><img src=\"https://assets.codepen.io/210284/fb_1.png\" alt=\"Facebook\" width=\"38\" style=\"height:auto;display:block;border:0;\" /></a>\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n                  </td>\r\n                </tr>\r\n              </table>\r\n            </td>\r\n          </tr>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </table>\r\n</body>\r\n</html>";
            return response;
        }

        public async Task SendEmailAsync(string from, string displayname, string to, string subject, string body, bool isBodyHtml = false)
        {
            await SendEmailAsync(from, displayname, new[] { to }, subject, body, isBodyHtml);
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

        public async Task SendEmailWithMimeAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.Email, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        public async Task SendEmailsToRecipientListAsync(List<MailRequest> recipientList)
        {
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.Email, _settings.Password);

            foreach (var mailRequest in recipientList)
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_settings.Email);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();

                await smtp.SendAsync(email);
            }

            await smtp.DisconnectAsync(true);
        }
    }
}
