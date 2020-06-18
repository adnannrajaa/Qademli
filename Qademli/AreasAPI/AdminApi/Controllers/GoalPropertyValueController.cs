using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalPropertyValueController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GoalPropertyValueController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/GoalPropertyValue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalPropertyValue>>> GetGoalPropertyValue()
        {
            return await _context.GoalPropertyValue.ToListAsync();
        }

        // GET: api/GoalPropertyValue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalPropertyValue>> GetGoalPropertyValue(int id)
        {
            var goalPropertyValue = await _context.GoalPropertyValue.FindAsync(id);

            if (goalPropertyValue == null)
            {
                return NotFound();
            }

            return goalPropertyValue;
        }

        // PUT: api/GoalPropertyValue/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalPropertyValue(int id, [FromForm]GoalPropertyUpsert obj)
        {
            if (id != obj.ID)
            {
                return BadRequest();
            }

            var finddata = _context.GoalPropertyValue.Find(id);
            finddata.Name = obj.Name;
            await _context.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/GoalPropertyValue
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostGoalPropertyValue([FromForm]GoalPropertyUpsert obj)
        {
            var isAlreadyExist = _context.GoalPropertyValue.Where(s => (s.GoalPropertyID == obj.GoalPropertyID && s.GoalId == obj.GoalID)).FirstOrDefault();
            if (isAlreadyExist != null)
            {
                return NoContent();
            }

            GoalPropertyValue newObj = new GoalPropertyValue();
            newObj.GoalPropertyID = obj.GoalPropertyID;
            newObj.Name = obj.Name;
            newObj.GoalId = obj.GoalID;

            _context.GoalPropertyValue.Add(newObj);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE: api/GoalPropertyValue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoalPropertyValue>> DeleteGoalPropertyValue(int id)
        {
            var goalPropertyValue = await _context.GoalPropertyValue.FindAsync(id);
            if (goalPropertyValue == null)
            {
                return NotFound();
            }

            _context.GoalPropertyValue.Remove(goalPropertyValue);
            await _context.SaveChangesAsync();

            return goalPropertyValue;
        }

        private bool GoalPropertyValueExists(int id)
        {
            return _context.GoalPropertyValue.Any(e => e.ID == id);
        }
    }

    public class GoalPropertyUpsert {
        public int ID { get; set; }
        public int GoalPropertyID { get; set; }
        public int GoalID { get; set; }
        public string Name { get; set; }
        public int GoalDetailID { get; set; }
    }
}
