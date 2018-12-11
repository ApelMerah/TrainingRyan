using Calvin.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calvin.API
{
    public class RegisterApiRequestModel
    {
        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string Username { set; get; }

        [Required]
        [StringLength(64)]
        public string Password { set; get; }
    }

    [Route("api/v1/value")]
    [ApiController]
    public class ValueApiController : ControllerBase
    {
        private readonly CalvinDbContext DB;

        public ValueApiController(CalvinDbContext calvinDbContext)
        {
            this.DB = calvinDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            var querydoang = DB.Employee.Select(Q => Q.Name).OrderBy(Q => Q); //deferred
            var e = await querydoang.ToListAsync(); //immediate
            return e;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody][Required] RegisterApiRequestModel model)
        {
            var divisionID = new Guid("35688a87-8e90-4858-b810-fedfdf241826");
            var e = new Employee
            {
                DivisionID = divisionID,
                EmployeeID = Guid.NewGuid(),
                Name = model.Username
            };

            DB.Employee.Add(e);
            await DB.SaveChangesAsync();

            return e.EmployeeID;
        }

        [HttpPost("{id:Guid}")]
        public async Task<ActionResult<bool>> Update(Guid id, [FromBody][Required] string name)
        {
            var e = await DB.Employee.Where(Q => Q.EmployeeID == id).FirstOrDefaultAsync();
            if (e == null)
            {
                return NotFound($"No employee with ID: {id}");
            }

            e.Name = name;
            await DB.SaveChangesAsync();

            return true;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var e = await DB.Employee.Where(Q => Q.EmployeeID == id).FirstOrDefaultAsync();
            if (e == null)
            {
                return NotFound($"No employee with ID: {id}");
            }

            DB.Employee.Remove(e);
            await DB.SaveChangesAsync();
            return true;
        }
    }
}
