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
            var data = _context.GoalPropertyValue.Include("GoalProperty").Where(s => s.GoalId == goalId);
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
