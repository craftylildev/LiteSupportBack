using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteSupport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using LiteSupport.DataModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LiteSupport.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class EmployeeController : Controller
    {
        private LSContext _context;

        public EmployeeController(LSContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get([FromQuery] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<EmployeeDetails> employee = from e in _context.Employee
                                                   join d in _context.Department
                                                   on e.DepartmentId equals d.DepartmentId
                                         select new EmployeeDetails
                                         {
                                             EmployeeId = e.EmployeeId,
                                             FirstName = e.FirstNameE,
                                             LastName = e.LastNameE,
                                             Username = e.Username,
                                             Email = e.EmailE,
                                             Phone = e.PhoneE,
                                             DepartmentId = e.DepartmentId,
                                             DepartmentName = d.DepartmentName

                                         };

            if (username != null)
            {
                employee = employee.Where(e => e.Username == username);
            }

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // GET api/Employee/5
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = _context.Employee.Single(m => m.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = from e in _context.Employee
                               where e.Username == employee.Username
                               select e;

            if (existingUser.Count<Employee>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.Employee.Add(employee);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = _context.Employee.Single(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Count(e => e.EmployeeId == id) > 0;
        }
    }
}
