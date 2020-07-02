using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.CustomAttributes;
using Qademli.Models.DatabaseModel;
using Qademli.Utility;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallSchedulesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CallSchedulesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/CallSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallSchedule>>> GetcallSchedule()
        {
            var record = await _context.User.Join(_context.callSchedule, u => u.ID, cs => cs.UserId, (u, cs) => new { u, s = cs })
              .Join(_context.callStatus,c=>c.s.Status ,s=> s.ID, (c, s) => new {c,s })
                .OrderByDescending(s => s.c.s.CallId)
                .Select(f => new
                {
                    f.c.u.FirstName,f.c.u.LastName,f.c.u.MiddleName,
                    f.c.u.Email,f.c.s.CallId,f.c.s.Mobile,f.c.s.CallDate,f.s.Name,f.s.ID
                }).ToListAsync();


            return Ok(record);
        }
        // GET: api/CallSchedules/CallStatus
        [HttpGet("CallStatus")]
        public async Task<ActionResult<IEnumerable<CallStatus>>> CallStatus()
        {
            return await _context.callStatus.ToListAsync();
        }

        // GET: api/CallSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CallSchedule>> GetCallSchedule(int id)
        {
            var callSchedule = await _context.callSchedule.FindAsync(id);

            if (callSchedule == null)
            {
                return NotFound();
            }

            return callSchedule;
        }

        // PUT: api/CallSchedules/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCallSchedule(int id, [FromForm]int Status)
        {
            var callSchedule = await _context.callSchedule.FindAsync(id);
            callSchedule.Status = Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/CallSchedules
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize(SD.User)]
        [HttpPost]
        public async Task<ActionResult<CallSchedule>> PostCallSchedule([FromForm]CallSchedule callSchedule)
        {
            _context.callSchedule.Add(callSchedule);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/CallSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CallSchedule>> DeleteCallSchedule(int id)
        {
            var callSchedule = await _context.callSchedule.FindAsync(id);
            if (callSchedule == null)
            {
                return NotFound();
            }

            _context.callSchedule.Remove(callSchedule);
            await _context.SaveChangesAsync();

            return callSchedule;
        }

        private bool CallScheduleExists(int id)
        {
            return _context.callSchedule.Any(e => e.CallId == id);
        }
    }
}
