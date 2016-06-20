using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using LiteSupport.Models;
using LiteSupport.DataModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LiteSupport.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class TicketController : Controller
    {
        private LSContext _context;

        public TicketController(LSContext context)
        {
            _context = context;
        }

        // GET: api/Ticket
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //IQueryable<TicketDetails> ticket = from t in _context.Ticket
            //                                   join ty in _context.Ttype
            //                                   on t.TtypeId equals ty.TtypeId
            //                                   join p in _context.Priority
            //                                   on t.PriorityId equals p.PriorityId
            //                                   join co in _context.Comment
            //                                   on t.TicketId equals co.TicketId
            //                                   join c in _context.Customer
            //                                   on t.CustomerId equals c.CustomerId
            //                                   join e in _context.Employee
            //                                   on co.EmployeeId equals e.EmployeeId
            //                                   orderby t.TicketId
            //                             select new TicketDetails
            //                             {
            //                                 TicketId = t.TicketId,
            //                                 Title = t.Title,
            //                                 DateCreatedT = t.DateCreatedT,
            //                                 TtypeName = ty.TtypeName,
            //                                 PriorityName = p.PriorityName,
            //                                 Description = t.Description,
            //                                 FirstNameC = c.FirstNameC,
            //                                 LastNameC = c.LastNameC,
            //                                 Company = c.Company,
            //                                 EmailC = c.EmailC,
            //                                 PhoneC = c.PhoneC,
            //                                 URL = c.URL,
            //                                 CommentId = co.CommentId,
            //                                 CommentMsg = co.CommentMsg,
            //                                 FirstNameE = e.FirstNameE,
            //                                 LastNameE = e.LastNameE
            //                             };

            IQueryable<object> ticket = from t in _context.Ticket
                                               join p in _context.Priority
                                               on t.PriorityId equals p.PriorityId
                                               join c in _context.Customer
                                               on t.CustomerId equals c.CustomerId
                                               orderby t.TicketId

                                               select new 
                                               {
                                                   TicketId = t.TicketId,
                                                   Title = t.Title,
                                                   DateCreatedT = t.DateCreatedT,
                                                   
                                                   PriorityName = p.PriorityName,

                                                   Company = c.Company
                                               };


            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // GET api/Ticket/5
        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Ticket ticket = _context.Ticket.Single(t => t.TicketId == id);

            IQueryable<object> ticket = from t in _context.Ticket
                                        join ty in _context.Ttype
                                        on t.TtypeId equals ty.TtypeId
                                        join p in _context.Priority
                                        on t.PriorityId equals p.PriorityId
                                        join c in _context.Customer
                                        on t.CustomerId equals c.CustomerId
                                        where t.TicketId == id
                                        
                                        select new
                                        {
                                            TicketId = t.TicketId,
                                            Title = t.Title,
                                            DateCreatedT = t.DateCreatedT,
                                            TtypeName = ty.TtypeName,
                                            PriorityName = p.PriorityName,
                                            Description = t.Description,

                                            FirstNameC = c.FirstNameC,
                                            LastNameC = c.LastNameC,
                                            Company = c.Company,
                                            EmailC = c.EmailC,
                                            PhoneC = c.PhoneC,
                                            URL = c.URL,

                                            Comment = from co in _context.Comment
                                                      join t in _context.Ticket
                                                      on co.TicketId equals t.TicketId

                                                      join e in _context.Employee
                                                      on co.EmployeeId equals e.EmployeeId

                                                      where co.TicketId == id
                                                      select new
                                                      {
                                                          CommentId = co.CommentId,
                                                          CommentMsg = co.CommentMsg,
                                                          FirstNameE = e.FirstNameE,
                                                          LastNameE = e.LastNameE,
                                                          DateCreatedC = co.DateCreatedC
                                                      }
                                        };




            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // POST api/Ticket
        [HttpPost]
        public IActionResult Post([FromBody]Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ticket.Add(ticket);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TicketExists(ticket.TicketId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTicket", new { id = ticket.TicketId }, ticket);

        }

        // PUT api/Ticket/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // DELETE api/Ticket/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ticket ticket = _context.Ticket.Single(t => t.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            _context.SaveChanges();

            return Ok(ticket);
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Count(t => t.TicketId == id) > 0;
        }
    }
}
