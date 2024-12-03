using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Firma.Dto.Requests
{
    public class AuthorizationRequest
    {
        public string client_id { get; set; } = default;
        public string client_secret { get; set; } = default;
        public string token_url { get; set; } = default;
    }
}
