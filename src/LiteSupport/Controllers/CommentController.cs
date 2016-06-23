using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteSupport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LiteSupport.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class CommentController : Controller
    {
        private LSContext _context;

        public CommentController(LSContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int? CommentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Comment> comment = from c in _context.Comment
                                             select c;
            if (comment == null)
            {
                return NotFound();
            }

            if (CommentId != null)
            {
                comment = comment.Where(com => com.CommentId == CommentId);
            }


            return Ok(comment);
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/Comment
        [HttpPost]
        //public IActionResult Post([FromBody]Comment comment)
        public IActionResult Post([FromBody]Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comment.Add(comment);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommentExists(comment.CommentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtRoute("GetComment", new { id = comment.CommentId }, comment);
            return Ok(comment);

        }



        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/Comment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comment comment = _context.Comment.Single(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            _context.SaveChanges();

            return Ok(comment);
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Count(c => c.CommentId == id) > 0;
        }
    }
}
