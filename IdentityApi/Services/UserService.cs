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
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace IdentityApi.Services
{

    public class UserService : IUserService
    {


        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IdentityContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public UserService(ILogger<UserService> logger, IdentityContext context, IMailService mailService, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _mailService = mailService;
        }

        public async Task<TDResponse<UserDto>> GetUserById(BaseRequest<long> req)
        {
            TDResponse<UserDto> response = new TDResponse<UserDto>();
            req.SetInfo("GetUserById");
            var id = req.Data;
            try
            {
                var user = await _context.User.Where(l => l.Id == id).FirstOrDefaultAsync();
                response.Data = _mapper.Map<UserDto>(user);
                response.SetSuccess();
                req.AddInfo(OperationMessages.Success);
                _logger.LogInformation(req.Info?.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                _logger.LogError(getException(e, "GetUserById"));
            }

            return response;
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


        public async Task<TDResponse<long>> SignInRequest(BaseRequest<UserRequest> req)
        {
            TDResponse<long> response = new TDResponse<long>();
            var userRequest = req.Data;
            req.SetInfo("SignInRequest");
            try
            {
                using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var us = _mapper.Map<User>(userRequest);
                        us.IsActive = null;
                        us.LastSeen = DateTimeOffset.UtcNow;
                        us.PasswordHash = HashHelper.ComputeSha256Hash(userRequest.Password);
                        if (await _context.User.Where(l => l.Email == us.Email && l.IsActive != false).AnyAsync())
                        {
                            response.SetError(OperationMessages.DuplicateMail);
                            req.AddInfo(OperationMessages.DuplicateMail);
                            _logger.LogInformation(req.Info?.ToString());
                            return response;
                        }

                        var existUser = await _context.User.Where(l => l.Username == us.Username && l.IsActive != false).FirstOrDefaultAsync();

                        if (existUser != null)
                        {
                            if (existUser.IsActive == true)
                            {
                                response.SetError(OperationMessages.DuplicateRecord);
                                req.AddInfo(OperationMessages.DuplicateRecord);
                                _logger.LogInformation(req.Info?.ToString());
                                return response;
                            }
                            else if (existUser.IsActive == null)
                            {
                                existUser.PasswordHash = us.PasswordHash;
                                existUser.Email = us.Email;
                                existUser.MobileUserId = us.MobileUserId;
                                existUser.IsAndroid = us.IsAndroid;
                                existUser.LastSeen = us.LastSeen;
                                existUser.UsingNFT = us.UsingNFT;
                            }
                        }
                        else
                        {
                            await _context.AddAsync(us);
                            await _context.SaveChangesAsync();
                        }

                        #region Create Token

                        var userToken = new UserToken()
                        {
                            CreatedDate = DateTimeOffset.UtcNow,
                            IsActive = true,
                            Token = new Random().Next(100000, 999999).ToString(),
                            UserId = existUser != null ? existUser.Id : us.Id
                        };
                        req.AddInfo("Token eklendi");
                        var tokenExist = await _context.UserToken.Where(l => l.UserId == userToken.UserId && l.IsActive == true).ToListAsync();
                        foreach (var t in tokenExist)
                        {
                            t.IsActive = false;
                        }
                        await _context.AddAsync(userToken);
                        #endregion
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        _mailService.SendMailAsync(us.Email, userToken.Token);
                        response.SetSuccess();
                        req.AddInfo(OperationMessages.Success);
                        _logger.LogInformation(req.Info?.ToString());
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                _logger.LogError(getException(e, "SignInRequest"));
            }

            return response;
        }


        public async Task<TDResponse> ActivateUser(BaseRequest<ActivationRequest> req)
        {
            TDResponse response = new TDResponse();
            req.SetInfo("ActivateUser");
            var userId = req.Data.userId;
            var token = req.Data.token;
            try
            {
                var xx = await _context.UserToken.Where(l => l.UserId == userId && l.Token == token && l.IsActive == true && l.CreatedDate < DateTimeOffset.UtcNow.AddMinutes(5)).FirstOrDefaultAsync();
                if (xx != null)
                {
                    xx.IsActive = false;
                    var _user = await _context.User.Where(l => l.Id == userId).FirstOrDefaultAsync();
                    _user.IsActive = true;
                    _user.LastSeen = DateTimeOffset.UtcNow;
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    req.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(req.Info?.ToString());
                }
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                req.AddInfo(OperationMessages.DbError);
                _logger.LogError(getException(e, "ActivateUser"));
            }
            return response;
        }

        public async Task<TDResponse> ResendToken(BaseRequest<long> req)
        {
            TDResponse response = new TDResponse();
            req.SetInfo("ResendToken");
            var userId = req.Data;
            try
            {
                var _user = await _context.User.Where(l => l.Id == userId).FirstOrDefaultAsync();
                if (_user == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    req.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(req.Info?.ToString());
                    return response;
                }
                else if (_user.IsActive == true)
                {
                    response.SetError(OperationMessages.UserAllreadyActive);
                    req.AddInfo(OperationMessages.UserAllreadyActive);
                    _logger.LogInformation(req.Info?.ToString());
                    return response;
                }

                var tokenExist = await _context.UserToken.Where(l => l.UserId == userId && l.IsActive == true).ToListAsync();
                foreach (var t in tokenExist)
                {
                    t.IsActive = false;
                }
                var newToken = new UserToken()
                {
                    CreatedDate = DateTimeOffset.UtcNow,
                    IsActive = true,
                    Token = new Random().Next(100000, 999999).ToString(),
                    UserId = userId
                };
                await _context.AddAsync(newToken);
                await _context.SaveChangesAsync();
                _mailService.SendMailAsync(_user.Email, newToken.Token);
                response.SetSuccess();
                req.AddInfo(OperationMessages.Success);
                _logger.LogInformation(req.Info?.ToString());

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                _logger.LogError(getException(e, "ResendToken"));
            }
            return response;
        }


        //public async Task<TDResponse> DeleteUserById(int id)
        //{
        //    TDResponse response = new TDResponse();
        //    try
        //    {
        //        var user = await _context.User.Where(l => l.Id == id).FirstOrDefaultAsync();
        //        if (user != null)
        //        {
        //            _context.Remove(user);
        //            response.SetSuccess();
        //        }
        //        else
        //        {
        //            response.SetError(OperationMessages.DbItemNotFound);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response.SetError(OperationMessages.DbError);
        //        _logger.LogError(getException(e, "DeleteUserById"));
        //    }

        //    return response;
        //}

        public async Task<TDResponse<AuthenticateResponse>> Login(BaseRequest<AuthenticateRequest> req)
        {

            req.SetInfo("Login");
            
            var model = req.Data;
            TDResponse<AuthenticateResponse> response = new TDResponse<AuthenticateResponse>();
            try
            {
                var userEnt = await _context.User.FirstOrDefaultAsync(x => x.Username == model.Username && x.IsActive == true);

                if (userEnt?.PasswordHash?.Equals(HashHelper.ComputeSha256Hash(model.Password)) != true)
                {
                    response.SetError(OperationMessages.AuthenticateError);
                    req.AddInfo(OperationMessages.AuthenticateError);
                    _logger.LogInformation(req.Info?.ToString());
                }
                else
                {
                    var user = _mapper.Map<User, UserDto>(userEnt);
                    var token = generateJwtToken(user);
                    response.Data = new AuthenticateResponse(user, token);
                    response.SetSuccess();
                    req.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(req.Info?.ToString());
                }
                throw new ArgumentNullException();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                req.AddInfo(OperationMessages.DbError);
                _logger.LogError(getException(e, "Login"));
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

        private string getException(Exception e,string action)
        {
            return "---Action : " + action + "--- \n  E.message: " + e.Message + "\n" + "E.inner:" + (e.InnerException?.Message ?? "") + "\n" + "E.StackTrace:" + e.StackTrace;
        }


    }
}