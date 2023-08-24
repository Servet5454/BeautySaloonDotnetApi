using GuzellikSalonuInterfaces.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Abstract
{
    public interface ITokenHandler
    {
        Task<Token> CreateToken(IConfiguration configuration);
    }
}
