using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Firma.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(AuthorizationRequest config);
        AuthorizationRequest LoadAuthorizationConfig();
    }
}
