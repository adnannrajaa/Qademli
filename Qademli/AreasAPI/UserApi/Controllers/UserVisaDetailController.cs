using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.Models.DatabaseModel;
using Qademli.Models.ViewModel;
using Qademli.Utility;

namespace Qademli.AreasAPI.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVisaDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserVisaDetailVM _viewModel;
        public UserVisaDetailController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _viewModel = new UserVisaDetailVM(_hostEnvironment);

        }

        //// GET: api/UserVisaDetail
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserVisaDetail>>> GetUserVisaDetail()
        //{
        //    return await _context.UserVisaDetail.ToListAsync();
        //}

        // GET: api/UserVisaDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVisaDetail>> GetUserVisaDetail(int id)
        {
            var userVisaDetail = await _context.UserVisaDetail.FirstOrDefaultAsync(s=>s.UserID==id);

            if (userVisaDetail == null)
            {
                return NotFound();
            }

            return userVisaDetail;
        }

        // PUT: api/UserVisaDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserVisaDetail(int id, UserVisaDetail userVisaDetail)
        {
            if (id != userVisaDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(userVisaDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserVisaDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserVisaDetail
        [HttpPost]
        public ActionResult PostUserVisaDetail([FromForm] UserVisaDetailUpsert obj)
        {
            if (ModelState.IsValid)
            {
                var userExist = _context.UserVisaDetail.FirstOrDefault(s => s.UserID == obj.UserID);
                if (userExist == null)
                {
                    UserVisaDetail userVisaDetail = _viewModel.Add(obj);
                    _context.UserVisaDetail.Add(userVisaDetail);
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    UserVisaDetail userVisaDetail = _context.UserVisaDetail.FirstOrDefault(x => x.UserID == obj.UserID);
                    userVisaDetail = _viewModel.Update(userVisaDetail, obj);
                    _context.Entry(userVisaDetail).State = EntityState.Modified;
                    _context.SaveChanges();

                    return NoContent();
                }

            }
            else
                return ValidationProblem();
        }

        // DELETE: api/UserVisaDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserVisaDetail>> DeleteUserVisaDetail(int id)
        {
            var userVisaDetail = await _context.UserVisaDetail.FindAsync(id);
            if (userVisaDetail == null)
            {
                return NotFound();
            }
            _viewModel.Delete(userVisaDetail);
            _context.UserVisaDetail.Remove(userVisaDetail);
            await _context.SaveChangesAsync();

            return userVisaDetail;
        }

        private bool UserVisaDetailExists(int id)
        {
            return _context.UserVisaDetail.Any(e => e.ID == id);
        }
    }

   
}
