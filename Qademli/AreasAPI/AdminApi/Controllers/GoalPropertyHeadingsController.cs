using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalPropertyHeadingsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GoalPropertyHeadingsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/GoalPropertyHeadings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalPropertyHeading>>> GetGoalPropertyHeading()
        {
            return await _context.GoalPropertyHeading.ToListAsync();
        }

        // GET: api/GoalPropertyHeadings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetGoalPropertyHeading(int id)
        {
            var goalPropertyHeading = await _context.GoalPropertyHeading.Where(s=>s.GoalPropId==id).ToListAsync();

            if (goalPropertyHeading == null)
            {
                return NotFound();
            }
            var PropertyHeadingList = new List<dynamic>();
            foreach (var g in goalPropertyHeading)
            {
                PropertyHeadingList.Add(new
                {
                    g.HeadingId,
                    g.GoalPropId,
                    g.Name,
                });
            }

            return PropertyHeadingList;
        }

        // PUT: api/GoalPropertyHeadings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalPropertyHeading(int id, [FromForm]string Name)
        {
            var goalPropertyHeading =await _context.GoalPropertyHeading.FindAsync(id);
            if (goalPropertyHeading == null)
            {
                return BadRequest();
            }

            goalPropertyHeading.Name = Name;
           await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/GoalPropertyHeadings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GoalPropertyHeading>> PostGoalPropertyHeading([FromForm]GoalPropertyHeading goalPropertyHeading)
        {
            var isAlreadyHeadingExist = _context.GoalPropertyHeading.Where(s => s.Name == goalPropertyHeading.Name).FirstOrDefault();
            if (isAlreadyHeadingExist !=null)
            {
                return NoContent();
            }
            _context.GoalPropertyHeading.Add(goalPropertyHeading);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/GoalPropertyHeadings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoalPropertyHeading>> DeleteGoalPropertyHeading(int id)
        {
            var goalPropertyHeading = await _context.GoalPropertyHeading.FindAsync(id);
            if (goalPropertyHeading == null)
            {
                return NotFound();
            }

            _context.GoalPropertyHeading.Remove(goalPropertyHeading);
            await _context.SaveChangesAsync();

            return goalPropertyHeading;
        }

        private bool GoalPropertyHeadingExists(int id)
        {
            return _context.GoalPropertyHeading.Any(e => e.HeadingId == id);
        }
    }
}
