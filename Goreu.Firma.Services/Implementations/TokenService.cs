using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Goreu.Firma.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public TokenService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> GenerateTokenAsync(AuthorizationRequest config)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
            {
                { "client_id", config.client_id },
                { "client_secret", config.client_secret }
            };

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(config.token_url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }

        public AuthorizationRequest LoadAuthorizationConfig()
        {
            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "FirmaPeru", "fwAuthorization.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo de configuración no fue encontrado.");
            }

            string jsonContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<AuthorizationRequest>(jsonContent);
        }
    }
}
