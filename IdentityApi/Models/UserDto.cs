using System.ComponentModel.DataAnnotations;
using SharedLibrary.Models;

namespace IdentityApi.Models
{

    public class UserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsApe { get; set; }


    }

    public class ActivationRequest
    {
        [Required]
        public long userId { get; set; }

        [Required]
        public string token { get; set; }
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
        public bool IsApe { get; set; }


        public AuthenticateResponse(UserDto user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Token = token;
            IsApe = user.IsApe;
        }
    }
}
