using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplictionFormStatusController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ApplictionFormStatusController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/ApplictionFormStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFamilyDetail>>> GetUserFamilyDetail()
        {
            return await _context.UserFamilyDetail.ToListAsync();
        }

        // GET: api/ApplictionFormStatus/5
        [HttpGet("{id}")]
        public ActionResult GetUserApplictionStatus(int id)
        {
            var IsPersonalInfo = _context.UserPersonalDetail.FirstOrDefault(s => s.UserID == id);
            if (IsPersonalInfo == null) { return NotFound(); }
            var IsEductionInfo = _context.UserEducationDetail.FirstOrDefault(s => s.UserID == id);
            if(IsEductionInfo == null) { return NotFound(); }
            var isFamilyInfo = _context.UserFamilyDetail.FirstOrDefault(s => s.UserID == id);
            if (isFamilyInfo == null) { return NotFound();  }
            var isVisaInfo = _context.UserVisaDetail.FirstOrDefault(s => s.UserID == id);
            if (isVisaInfo == null) { return NotFound();  }

     
            return Ok();
        }

        [HttpGet("{id}/{Goalid}")]
        public ActionResult GetUserAppliction(int id,int Goalid)
        {

            var IsApplicationSubmitted = _context.Application.FirstOrDefault(s => (s.UserID == id && s.GoalID==Goalid));
            if (IsApplicationSubmitted != null) { return NoContent(); }

            return Ok();
        }




        // PUT: api/ApplictionFormStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFamilyDetail(int id, UserFamilyDetail userFamilyDetail)
        {
            if (id != userFamilyDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(userFamilyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFamilyDetailExists(id))
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

        // POST: api/ApplictionFormStatus
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserFamilyDetail>> PostUserFamilyDetail(UserFamilyDetail userFamilyDetail)
        {
            _context.UserFamilyDetail.Add(userFamilyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserFamilyDetail", new { id = userFamilyDetail.ID }, userFamilyDetail);
        }

        // DELETE: api/ApplictionFormStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserFamilyDetail>> DeleteUserFamilyDetail(int id)
        {
            var userFamilyDetail = await _context.UserFamilyDetail.FindAsync(id);
            if (userFamilyDetail == null)
            {
                return NotFound();
            }

            _context.UserFamilyDetail.Remove(userFamilyDetail);
            await _context.SaveChangesAsync();

            return userFamilyDetail;
        }

        private bool UserFamilyDetailExists(int id)
        {
            return _context.UserFamilyDetail.Any(e => e.ID == id);
        }
    }
}
