
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Models;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ProgressApi.Helpers
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                attachUserToContext(context, token);
            }

            await _next(context);
        }

        private async void attachUserToContext(HttpContext context, string token)
        {
            try
            {
                UserDto? userDto = null;
                var handler = new HttpClientHandler();

                handler.ServerCertificateCustomValidationCallback =
                (
                  HttpRequestMessage message,
                  X509Certificate2 cert,
                  X509Chain chain,
                  SslPolicyErrors errors
                 ) => { return true; }; //TODO: Prodda silinmeli

                using (HttpClient client = new HttpClient(handler))
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(_configuration["IdentityEndpoint"] + "/api/user/checkToken?token=" + token),
                    };

                    var response = client.SendAsync(request).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        userDto = JsonConvert.DeserializeObject<TDResponse<UserDto>>(content)?.Data;
                    }
                }
                context.Items["User"] = userDto;


            }
            catch (Exception e)
            {

            }
        }
    }
}
