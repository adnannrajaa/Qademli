﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;
using Qademli.Models.ViewModel;

namespace Qademli.AreasAPI.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserEducationDetailVM viewModel;


        public UserEducationDetailController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            viewModel = new UserEducationDetailVM(_hostEnvironment);
        }

        // GET: api/UserEducationDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEducationDetail>> GetUserEducationDetail(int id)
        {
            var userEducationDetail = await _context.UserEducationDetail.FirstOrDefaultAsync(x => x.UserID == id);

            if (userEducationDetail == null)
            {
                return NotFound();
            }

            return userEducationDetail;
        }

        // PUT: api/UserEducationDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEducationDetail(int id, [FromForm]UserEducationDetailUpsert obj)
        {
            UserEducationDetail userEducationDetail = await _context.UserEducationDetail.FirstOrDefaultAsync(x => x.UserID == obj.UserID);
            userEducationDetail = viewModel.Update(userEducationDetail, obj);

            _context.Entry(userEducationDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEducationDetailExists(id))
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

        // POST: api/UserEducationDetail
        [HttpPost]
        public ActionResult PostUserEducationDetail([FromForm]UserEducationDetailUpsert obj)
        {
            if (ModelState.IsValid)
            {


                var userExist = _context.UserEducationDetail.FirstOrDefault(s => s.UserID == obj.UserID);
                if (userExist == null)
                {
                    UserEducationDetail userEducationDetail = viewModel.Add(obj);
                    _context.UserEducationDetail.Add(userEducationDetail);
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    UserEducationDetail userEducationDetail = _context.UserEducationDetail.FirstOrDefault(x => x.UserID == obj.UserID);
                    userEducationDetail = viewModel.Update(userEducationDetail, obj);

                    _context.Entry(userEducationDetail).State = EntityState.Modified;
                    _context.SaveChanges();

                    return NoContent();
                }
            }
            else
            {
                return ValidationProblem();
            }

        }

        // DELETE: api/UserEducationDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserEducationDetail>> DeleteUserEducationDetail(int id)
        {
            var userEducationDetail = await _context.UserEducationDetail.FindAsync(id);
            if (userEducationDetail == null)
            {
                return NotFound();
            }
            viewModel.Delete(userEducationDetail);
            _context.UserEducationDetail.Remove(userEducationDetail);
            await _context.SaveChangesAsync();

            return userEducationDetail;
        }

        private bool UserEducationDetailExists(int id)
        {
            return _context.UserEducationDetail.Any(e => e.ID == id);
        }
    }
}
