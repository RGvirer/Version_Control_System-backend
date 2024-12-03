using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            // טוענים את כל המשתמשים יחד עם המידע על הרפוזיטורים שלהם
            var users = _ibl.GetAll().ToList();

            return Ok(users);
        }


        // GET api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            try
            {
                var userDto = _ibl.Get(id);

                if (userDto == null)
                {
                    return NotFound(); // מחזיר 404 אם המשתמש לא נמצא
                }

                return Ok(userDto); // מחזיר 200 עם ה-UserDTO שנמצא
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/User
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User cannot be null");
            }

            try
            {
                var success = _ibl.AddNew(userDto);
                if (success)
                {
                    return CreatedAtAction(nameof(Get), new { id = userDto.UserId }, userDto);
                }
                return StatusCode(500, "Failed to add new user.");
            }
            catch (Exception ex)
            {
                // הוספת פרטי השגיאה לקובץ הלוג או למסוף
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDTO userDto)
        {
            if (userDto == null || userDto.UserId != id)
            {
                return BadRequest("User ID mismatch");
            }

            var existingUser = _ibl.Get(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(userDto);
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
            var success = _ibl.Delete(id);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }
    }
}