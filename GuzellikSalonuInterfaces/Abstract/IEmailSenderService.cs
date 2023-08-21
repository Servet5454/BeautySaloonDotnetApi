﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Abstract
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject,string message);
    }
}
