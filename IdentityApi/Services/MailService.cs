using IdentityApi.Models;
using IdentityApi.Entities;
using IdentityApi.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using System.Net.Mail;
using System.Net;

namespace IdentityApi.Services
{

    public class MailService : IMailService
    {


        private readonly ILogger<MailService> _logger;
        private readonly IMapper _mapper;
        private readonly IdentityContext _context;
        private readonly IConfiguration _configuration;

        public MailService(ILogger<MailService> logger, IdentityContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }



        public bool SendMail(string mailAdress,string token)
        {
            try
            {
                SmtpClient client = new SmtpClient(_configuration["MailConfigs:SignInMail:MailServer"], Int32.Parse(_configuration["MailConfigs:SignInMail:MailPort"]));
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = Boolean.Parse(_configuration["MailConfigs:SignInMail:EnableSsl"]);
                client.Credentials = new NetworkCredential
                {
                    UserName = _configuration["MailConfigs:SignInMail:SenderMail"],
                    Password = _configuration["MailConfigs:SignInMail:SenderPassword"]
                };

                MailAddress from = new MailAddress(_configuration["MailConfigs:SignInMail:SenderMail"]);
                MailAddress to = new MailAddress(mailAdress);

                MailMessage mm = new MailMessage(from, to);
                mm.Subject = _configuration["MailConfigs:SignInMail:Topic"];
                mm.Body = _configuration["MailConfigs:SignInMail:Body"];
                mm.IsBodyHtml = Boolean.Parse(_configuration["MailConfigs:SignInMail:IsBodyHtml"]);
                client.Send(mm);
            }
            catch (Exception e)
            {
                //todo: addlog
                return false;
            }
            return true;
        }
    }
}