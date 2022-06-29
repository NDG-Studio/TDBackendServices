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

namespace IdentityApi.Services
{

    public class UserService : IUserService
    {


        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IdentityContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ILogger<UserService> logger, IdentityContext context, IMapper mapper,IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration=configuration;
        }

        public async Task<TDResponse<UserDto>> GetUserById(long id)
        {
            TDResponse<UserDto> response = new TDResponse<UserDto>();
            try
            {
                var user = await _context.User.Where(l => l.Id == id).FirstOrDefaultAsync();
                response.Data = _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }

            return response;
        }

        public async Task<TDResponse<UserDto>> CheckToken(string token)
        {
            TDResponse<UserDto> response = new TDResponse<UserDto>();
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSECRET"));
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                response.Data = GetUserById(userId).Result.Data;
                response.SetSuccess();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.TokenFail);
            }

            return response;
        }


        public async Task<TDResponse> AddUser(UserRequest userRequest)
        {
            TDResponse response = new TDResponse();
            try
            {
                var us = _mapper.Map<User>(userRequest);
                us.PasswordHash = HashHelper.ComputeSha256Hash(userRequest.Password);
                await _context.AddAsync(us);
                await _context.SaveChangesAsync();
                response.SetSuccess();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }

            return response;
        }

        public async Task<TDResponse> DeleteUserById(int id)
        {
            TDResponse response = new TDResponse();
            try
            {
                var user = await _context.User.Where(l => l.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    _context.Remove(user);
                    response.SetSuccess();
                }
                else
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                }
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }

            return response;
        }

        public async Task<TDResponse<AuthenticateResponse>> Login(AuthenticateRequest model)
        {
            TDResponse<AuthenticateResponse> response = new TDResponse<AuthenticateResponse>();
            var userEnt = await _context.User.FirstOrDefaultAsync(x => x.Username == model.Username && x.IsActive!=false);

            if (!userEnt.PasswordHash.Equals(HashHelper.ComputeSha256Hash(model.Password)))
            {
                response.SetError(OperationMessages.AuthenticateError);
            }
            else
            {
                var user = _mapper.Map<User, UserDto>(userEnt);
                var token = generateJwtToken(user);
                response.Data = new AuthenticateResponse(user, token);
                response.SetSuccess();
            }

            return response;
        }

        private string generateJwtToken(UserDto user)
        {
            // generate token that is valid for 23 HOURS
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSECRET"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(23),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}