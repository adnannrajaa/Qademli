using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Qademli.Models.DatabaseModel;
using Qademli.Models.ViewModel;
using Qademli.SecureWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Qademli
{
    public interface IUserService
    {
        User Authenticate(LoginVM _User);
        IEnumerable<User> GetAll();

    }

    public class UserService : IUserService
    {
        private readonly AppSetting _appsettings;
        private readonly  ApplicationDBContext _db;

        public UserService(IOptions<AppSetting> appSettings, ApplicationDBContext db)
        {
            _appsettings = appSettings.Value;
            _db = db;
        }
        public User Authenticate(LoginVM _User)
        {
            var user = _db.User.FirstOrDefault(u => u.Email == _User.Email && u.Password==_User.Password);
            // return null if user not found
            if (user == null)
                return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var RoleName = _db.User.FirstOrDefault(u=>u.ID==user.ID).Role;
                var key = Encoding.ASCII.GetBytes(_appsettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.ID.ToString() ),
                    new Claim(ClaimTypes.Role, RoleName)

                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
           

        }
        public IEnumerable<User> GetAll()
        {
            return _db.User.ToList();
        }

    }
}
