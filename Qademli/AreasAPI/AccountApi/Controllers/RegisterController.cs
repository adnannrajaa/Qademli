using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RegisterController(ApplicationDBContext context)
        {
            _context = context;
        }
        // POST: api/Register
        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostUser([FromForm]Register creds)
        {
            var checkUser = _context.User.Any(x => x.Email == creds.Email);
            if (checkUser)
            {
                return NoContent();
            }
            User user = new User { 
                FirstName = creds.FirstName,
                MiddleName = creds.MiddleName,
                LastName = creds.LastName,
                Email=creds.Email,
                Password= creds.Password,
                Role = SD.User
            };
            
            _context.User.Add(user);
            _context.SaveChanges();

            return Ok();
        }

    }

    public class Register {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
