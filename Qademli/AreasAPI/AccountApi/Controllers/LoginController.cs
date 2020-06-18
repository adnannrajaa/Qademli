

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Qademli.Models.ViewModel;
using Qademli.SecureWebApi.Helpers;

namespace Qademli.AreasAPI.AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private IConfiguration _config;
        public LoginController(ApplicationDBContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginUser([FromForm]LoginVM login)
        {
            if (ModelState.IsValid)
            {

                var user = new LoginViewModel(_db).AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = new JWTHandler(_config).GenerateJSONWebToken(user);
                    HttpContext.Session.SetString("token", tokenString);

                    return Ok(new { Token = tokenString, UserId = user.ID, UserName = user.FirstName + user.LastName });
                }
                return Forbid();
            }
            else
            {
                return NotFound();
            }
        }
    }
}