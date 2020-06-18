using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Qademli.Models.DatabaseModel;
using Qademli.SecureWebApi.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Qademli.Models.ViewModel
{
    public class LoginViewModel
    {
        private readonly ApplicationDBContext _db;
        public LoginViewModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public User AuthenticateUser(LoginVM login)
        {

            User user = _db.User.FirstOrDefault(x => x.Email == login.Email
                                                && x.Password == login.Password);
            return user;
        }

    }

    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
