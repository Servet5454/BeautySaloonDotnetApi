using GuzellikSalonuInterfaces.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Abstract
{
    public interface IEmailService
    {
        Task SendEmailWithMimeAsync(MailRequest mailRequest);
        Task<string> GetHtmlContentAsync();
        Task SendEmailAsync(string from,string displayname,string to, string subject,string body,bool isBodyHtml =false);
        Task SendEmailAsync(string from, string displayname, string[] tos, string subject, string body, bool isBodyHtml = false);

    }
}
