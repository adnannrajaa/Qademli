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
        private readonly IUserService _userService;

        public LoginController(ApplicationDBContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginUser([FromForm]LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Authenticate(login);
                if (user != null)
                {
                    var token = user.Token;
                    return Ok(new { Token = token});
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