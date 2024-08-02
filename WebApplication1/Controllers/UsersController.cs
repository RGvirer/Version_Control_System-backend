using DAL.Models; // ודא שזה המודל הנכון שלך
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBL.IUserBL _ibl;

        public UserController(IBL.IUserBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _ibl.GetAll().ToList(); // אם GetAll מחזיר IEnumerable<User>
            return Ok(users);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _ibl.Get(id); // אם Get מחזיר User
            if (user == null)
            {
                return NotFound();
        }
            return Ok(user);
        }

        // POST api/User
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
        }

            var success = _ibl.AddNew(user); // אם AddNew מקבל User
            if (success)
            {
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.UserId != id)
            {
                return BadRequest("User ID mismatch");
            }

            var existingUser = _ibl.Get(id); // אם Get מחזיר User
            if (existingUser == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(user); // אם Update מקבל User
            if (success)
        {
                return NoContent();
        }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUser = _ibl.Get(id); // אם Get מחזיר User
            if (existingUser == null)
            {
                return NotFound();
            }

            var success = _ibl.Delete(existingUser); // אם Delete מקבל User
            if (success)
        {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }
    }
}
