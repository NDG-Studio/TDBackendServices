using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace IdentityApi.Models
{

    public class UserRequest
    {
        public long Id { get; set; }=0;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? MobileUserId { get; set; }
        public bool? IsAndroid { get; set; }
        

    }

    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserDto user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
    }
}
