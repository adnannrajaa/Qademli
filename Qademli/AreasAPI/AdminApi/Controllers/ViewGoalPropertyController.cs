using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewGoalPropertyController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ViewGoalPropertyController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/ViewGoalProperty
        [HttpGet("{goalId}", Name = "Get")]
        public JsonResult Get(int goalId)
        {
            JsonResult result = new JsonResult(new { });
            var data = _context.GoalPropertyValue.Include("GoalProperty").Join(_context.GoalPropertyHeading , g=>g.GoalHeadingID,h=>h.HeadingId,(g,h)=>new {g,h })
                .Where(s => s.g.GoalId == goalId).Select(f=> new { 
                f.g.ID,
                f.g.Name,
                f.g.GoalId,
                f.g.GoalProperty,
                f.g.GoalPropertyID,
                HeadingName = f.h.Name,
                HeadingId=f.h.HeadingId,
                });
            result.Value = new { Data = data };
            return result;
        }

        // GET: api/ViewGoalProperty/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ViewGoalProperty
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ViewGoalProperty/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
