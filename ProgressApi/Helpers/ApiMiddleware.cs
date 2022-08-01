
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
using Newtonsoft.Json.Linq;

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
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                InfoDto? info = null;
                var yy = context.Request.Body;
                context.Request.EnableBuffering();

                var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
                await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                var requestContent = Encoding.UTF8.GetString(buffer);
                context.Request.Body.Position = 0;
                JObject o = JObject.Parse(requestContent);
                var i = o["info"] ?? o["Info"];
                if (i != null)
                {
                    info = JsonConvert.DeserializeObject<InfoDto>(i.ToString());
                }


                if (token != null && info != null)
                {
                    attachUserToContext(context, token, info);
                }
                context.Request.Body.Position = 0;
                await _next(context);
            }
            catch (Exception e)
            {

            }
        }

        private async void attachUserToContext(HttpContext context, string token, InfoDto info)
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
                 ) =>
                { return true; }; //TODO: Prodda silinmeli

                using (HttpClient client = new HttpClient(handler))
                {
                    //var request = new HttpRequestMessage
                    //{
                    //    Method = HttpMethod.Post,
                    //    RequestUri = new Uri(_configuration["IdentityEndpoint"] + "/api/user/checkToken"),
                    //    Content = new StringContent((new BaseRequest<string>() { Data = token, Info = info }).ToString()!, Encoding.UTF8, "application/json")

                    //};

                    var response = client.PostAsync(new Uri(_configuration["IdentityEndpoint"] + "/api/user/checkToken"),
                        new StringContent(JsonConvert.SerializeObject((new BaseRequest<string>() { Data = token, Info = info })), Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        userDto = JsonConvert.DeserializeObject<TDResponse<UserDto>>(content)?.Data;
                        context.Items["User"] = userDto;
                    }
                }



            }
            catch (Exception e)
            {

            }
        }
    }
}
