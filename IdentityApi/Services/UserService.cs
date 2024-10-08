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
            var info = InfoDetail.CreateInfo(req, "GetUserById");
            var id = req.Data;
            try
            {
                var user = await _context.User.Where(l => l.Id == id).FirstOrDefaultAsync();
                response.Data = _mapper.Map<UserDto>(user);
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }
        public async Task<TDResponse<UserDto>> GetUserById(long id)
        {
            TDResponse<UserDto> response = new TDResponse<UserDto>();
            try
            {
                var user = await _context.User.Where(l => l.Id == id).FirstOrDefaultAsync();
                user!.LastSeen = DateTimeOffset.UtcNow;
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }

            return response;
        }

        public async Task<TDResponse<UserDto>> CheckToken(BaseRequest<string> req)
        {

            TDResponse<UserDto> response = new TDResponse<UserDto>();
            var info = InfoDetail.CreateInfo(req, "CheckToken");
            try
            {
                var token = req.Data;
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
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.TokenFail);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        [Obsolete("deprecated")]
        public async Task<TDResponse<long>> SignInRequest(BaseRequest<UserRequest> req)
        {
            TDResponse<long> response = new TDResponse<long>();
            var userRequest = req.Data;
            var info = InfoDetail.CreateInfo(req, "SignInRequest");
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
                            info.AddInfo(OperationMessages.DuplicateMail);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }

                        var existUser = await _context.User.Where(l => l.Username == us.Username && l.IsActive != false).FirstOrDefaultAsync();

                        if (existUser != null)
                        {
                            if (existUser.IsActive == true)
                            {
                                response.SetError(OperationMessages.DuplicateRecord);
                                info.AddInfo(OperationMessages.DuplicateRecord);
                                _logger.LogInformation(info.ToString());
                                return response;
                            }
                            else if (existUser.IsActive == null)
                            {
                                existUser.PasswordHash = us.PasswordHash;
                                existUser.Email = us.Email;
                                existUser.MobileUserId = us.MobileUserId;
                                existUser.IsAndroid = us.IsAndroid;
                                existUser.LastSeen = us.LastSeen;
                                existUser.IsApe = us.IsApe;
                                response.Data = existUser.Id;
                            }
                        }
                        else
                        {
                            await _context.AddAsync(us);
                            await _context.SaveChangesAsync();
                            response.Data = us.Id;
                        }

                        #region Create Token

                        var userToken = new UserToken()
                        {
                            CreatedDate = DateTimeOffset.UtcNow,
                            IsActive = true,
                            Token = new Random().Next(100000, 999999).ToString(),
                            UserId = existUser != null ? existUser.Id : us.Id
                        };
                        info.AddInfo("Token eklendi");
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
                        info.AddInfo(OperationMessages.Success);
                        _logger.LogInformation(info.ToString());
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
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<long>> SignInRequestV2(BaseRequest<UserRequest> req)
        {
            TDResponse<long> response = new TDResponse<long>();
            var userRequest = req.Data;
            var info = InfoDetail.CreateInfo(req, "SignInRequestV2");
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
                            info.AddInfo(OperationMessages.DuplicateMail);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }

                        var existUser = await _context.User.Where(l => l.Username == us.Username && l.IsActive == true).FirstOrDefaultAsync();

                        if (existUser != null)
                        {
                            response.SetError(OperationMessages.DuplicateRecord);
                            info.AddInfo(OperationMessages.DuplicateRecord);
                            _logger.LogInformation(info.ToString());
                            return response;
                        }
                        else
                        {
                            var tutUser = await _context.User.Where(l => l.MobileUserId == req.Info.DeviceId && l.MobileUserId != null).FirstOrDefaultAsync();
                            if (tutUser == null)
                            {
                                response.SetError(OperationMessages.InputError);
                                info.AddInfo(OperationMessages.InputError);
                                _logger.LogInformation(info.ToString());
                                return response;
                            }
                            if (tutUser.IsActive == true)
                            {
                                response.SetError(OperationMessages.DuplicateRecord);
                                info.AddInfo(OperationMessages.DuplicateRecord);
                                _logger.LogInformation(info.ToString());
                                return response;
                            }
                            else if (tutUser.IsActive == null)
                            {
                                tutUser.PasswordHash = us.PasswordHash;
                                tutUser.Email = us.Email;
                                tutUser.Username = us.Username;
                                tutUser.LastSeen = us.LastSeen;
                                tutUser.IsApe = us.IsApe;
                                response.Data = tutUser.Id;
                            }
                            else
                            {
                                tutUser.PasswordHash = us.PasswordHash;
                                tutUser.Email = us.Email;
                                tutUser.LastSeen = us.LastSeen;
                                tutUser.IsApe = us.IsApe;
                                tutUser.Username = us.Username;
                            }
                            await _context.SaveChangesAsync();
                            response.Data = tutUser.Id;
                        }

                        #region Create Token

                        var userToken = new UserToken()
                        {
                            CreatedDate = DateTimeOffset.UtcNow,
                            IsActive = true,
                            Token = new Random().Next(100000, 999999).ToString(),
                            UserId = response.Data
                        };
                        info.AddInfo("Token eklendi");
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
                        info.AddInfo(OperationMessages.Success);
                        _logger.LogInformation(info.ToString());
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
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }


        public async Task<TDResponse> ActivateUser(BaseRequest<ActivationRequest> req)
        {
            TDResponse response = new TDResponse();
            var userId = req.Data.userId;
            var info = InfoDetail.CreateInfo(req, "ActivateUser");
            info.SetUser(userId);
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
                    _user.FirstLogInDate = DateTimeOffset.UtcNow;
                    _user.MobileUserId = null;
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());
                }
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }

        public async Task<TDResponse> ResendToken(BaseRequest<long> req)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "ResendToken");
            var userId = req.Data;
            info.SetUser(userId);
            try
            {
                var _user = await _context.User.Where(l => l.Id == userId).FirstOrDefaultAsync();
                if (_user == null)
                {
                    response.SetError(OperationMessages.DbItemNotFound);
                    info.AddInfo(OperationMessages.DbItemNotFound);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                else if (_user.IsActive == true)
                {
                    response.SetError(OperationMessages.UserAllreadyActive);
                    info.AddInfo(OperationMessages.UserAllreadyActive);
                    _logger.LogInformation(info.ToString());
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
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }


        public async Task<TDResponse> DeleteUserByUsername(BaseRequest<string> req,UserDto user)
        {
            TDResponse response = new TDResponse();
            try
            {
                var ent = await _context.User.Where(l => l.Username == req.Data).FirstOrDefaultAsync();
                if (ent != null && user.Id==1)
                {
                    ent.IsActive = false;
                    await _context.SaveChangesAsync();
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

        public async Task<TDResponse<AuthenticateResponse>> Login(BaseRequest<AuthenticateRequest> req)
        {

            var info = InfoDetail.CreateInfo(req, "Login");

            var model = req.Data;
            TDResponse<AuthenticateResponse> response = new TDResponse<AuthenticateResponse>();
            try
            {
                var userEnt = await _context.User.FirstOrDefaultAsync(x => x.Username == model.Username && x.IsActive == true);

                if (userEnt?.PasswordHash?.Equals(HashHelper.ComputeSha256Hash(model.Password)) != true)
                {
                    response.SetError(OperationMessages.AuthenticateError);
                    info.AddInfo(OperationMessages.AuthenticateError);
                    _logger.LogInformation(info.ToString());
                }
                else
                {
                    var user = _mapper.Map<User, UserDto>(userEnt);
                    var token = generateJwtToken(user);
                    response.Data = new AuthenticateResponse(user, token);
                    response.SetSuccess();
                    info.AddInfo(OperationMessages.Success);
                    _logger.LogInformation(info.ToString());

                }

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<AuthenticateResponse>> LoginWithDeviceId(BaseRequest req)
        {

            var info = InfoDetail.CreateInfo(req, "LoginWithDeviceId");

            TDResponse<AuthenticateResponse> response = new TDResponse<AuthenticateResponse>();
            try
            {
                var userEnt = await _context.User.Where(x => x.MobileUserId == req.Info.DeviceId && x.IsActive == true).FirstOrDefaultAsync();
                if (userEnt == null)
                {
                    await _context.AddAsync(new User()
                    {
                        IsActive = true,
                        IsAndroid = false,
                        Email = "",
                        FirstLogInDate = DateTimeOffset.UtcNow,
                        LastSeen = DateTimeOffset.UtcNow,
                        PasswordHash = null,
                        MobileUserId = req.Info.DeviceId,
                        Username = "",
                        IsTutorialDone = false,
                        IsApe = false
                    });
                    await _context.SaveChangesAsync();
                    userEnt = await _context.User.Where(x => x.MobileUserId == req.Info.DeviceId && x.IsActive == true).FirstOrDefaultAsync();
                    userEnt.Username = "user_" + userEnt.Id;
                    userEnt.Email = "user_" + userEnt.Id;
                    await _context.SaveChangesAsync();
                }


                var user = _mapper.Map<User, UserDto>(userEnt);
                var token = generateJwtToken(user);
                response.Data = new AuthenticateResponse(user, token);
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());


            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<string>> ChangeUsername(BaseRequest<string> req,UserDto user)
        {

            var info = InfoDetail.CreateInfo(req, "ChangeUsername");

            TDResponse<string> response = new TDResponse<string>();
            try
            {
                var userEnt = await _context.User.Where(x => x.Id == user.Id && x.IsActive == true).FirstOrDefaultAsync();
                var userExist = await _context.User.Where(l => l.Username == req.Data && l.IsActive==true).FirstOrDefaultAsync();
                if (userExist!=null || userEnt == null)
                {
                    response.SetError(OperationMessages.DuplicateRecord);
                    info.AddInfo(OperationMessages.DuplicateRecord);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                userEnt.Username = req.Data;
                await _context.SaveChangesAsync();
                response.Data = userEnt.Username;
                response.SetSuccess(OperationMessages.ChangeNameSuccess);
                info.AddInfo(OperationMessages.ChangeNameSuccess);
                _logger.LogInformation(info.ToString());


            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<AuthenticateResponse>> LoginWithApple(BaseRequest<string> req)
        {

            var info = InfoDetail.CreateInfo(req, "LoginWithApple");

            TDResponse<AuthenticateResponse> response = new TDResponse<AuthenticateResponse>();
            try
            {
                var userEnt = await _context.User.Where(x => x.AppleId == req.Data && x.IsActive == true).FirstOrDefaultAsync();
                if (userEnt == null)
                {
                    var deviceUser = await _context.User.Where(x => x.MobileUserId == req.Info.DeviceId && x.IsActive == false).FirstOrDefaultAsync();
                    if (deviceUser == null)
                    {

                        await _context.AddAsync(new User()
                        {
                            IsActive = true,
                            IsAndroid = false,
                            Email = "",
                            IsTutorialDone = false,
                            AppleId = req.Data,
                            FacebookId = null,
                            GooglePlayId = null,
                            FirstLogInDate = DateTimeOffset.UtcNow,
                            LastSeen = DateTimeOffset.UtcNow,
                            PasswordHash = null,
                            MobileUserId = null,
                            Username = "",
                            IsApe = false
                        });
                        await _context.SaveChangesAsync();
                        userEnt = await _context.User.Where(x => x.AppleId == req.Data && x.IsActive == true).FirstOrDefaultAsync();
                        userEnt.Username = "user_" + userEnt.Id;
                        userEnt.Email = "user_" + userEnt.Id;
                    }
                    else
                    {
                        deviceUser.IsActive = true;
                        deviceUser.AppleId = req.Data;
                        deviceUser.MobileUserId = null;
                    }
                    await _context.SaveChangesAsync();
                    userEnt = await _context.User.Where(x => x.AppleId == req.Data && x.IsActive == true).FirstOrDefaultAsync();
                }

                var user = _mapper.Map<User, UserDto>(userEnt);
                var token = generateJwtToken(user);
                response.Data = new AuthenticateResponse(user, token);
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());


            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse<AuthenticateResponse>> LoginWithFacebook(BaseRequest<string> req)
        {

            var info = InfoDetail.CreateInfo(req, "LoginWithFacebook");

            TDResponse<AuthenticateResponse> response = new TDResponse<AuthenticateResponse>();
            try
            {
                var userEnt = await _context.User.Where(x => x.FacebookId == req.Data && x.IsActive == true).FirstOrDefaultAsync();
                if (userEnt == null)
                {
                    var deviceUser = await _context.User.Where(x => x.MobileUserId == req.Info.DeviceId && x.IsActive == false).FirstOrDefaultAsync();
                    if (deviceUser == null)
                    {

                        await _context.AddAsync(new User()
                        {
                            IsActive = true,
                            IsAndroid = false,
                            Email = "",
                            IsTutorialDone = false,
                            AppleId = null,
                            FacebookId = req.Data,
                            GooglePlayId = null,
                            FirstLogInDate = DateTimeOffset.UtcNow,
                            LastSeen = DateTimeOffset.UtcNow,
                            PasswordHash = null,
                            MobileUserId = null,
                            Username = "",
                            IsApe = false
                        });
                        await _context.SaveChangesAsync();
                        userEnt = await _context.User.Where(x => x.FacebookId == req.Data && x.IsActive == true).FirstOrDefaultAsync();
                        userEnt.Username = "user_" + userEnt.Id;
                        userEnt.Email = "user_" + userEnt.Id;
                    }
                    else
                    {
                        deviceUser.IsActive = true;
                        deviceUser.FacebookId = req.Data;
                        deviceUser.MobileUserId = null;
                    }
                    await _context.SaveChangesAsync();
                    userEnt = await _context.User.Where(x => x.FacebookId == req.Data && x.IsActive == true).FirstOrDefaultAsync();
                }

                var user = _mapper.Map<User, UserDto>(userEnt);
                var token = generateJwtToken(user);
                response.Data = new AuthenticateResponse(user, token);
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());


            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }

            return response;
        }

        public async Task<TDResponse> TutorialDone(BaseRequest req, UserDto user)
        {

            var info = InfoDetail.CreateInfo(req, "TutorialDone");

            TDResponse response = new TDResponse();
            try
            {
                var userEnt = await _context.User.Where(x => x.Id == user.Id && x.IsActive == true).FirstOrDefaultAsync();
                if (userEnt == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                userEnt.IsTutorialDone = true;
                await _context.SaveChangesAsync();
                response.SetSuccess();
                info.AddInfo(OperationMessages.Success);
                _logger.LogInformation(info.ToString());
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
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