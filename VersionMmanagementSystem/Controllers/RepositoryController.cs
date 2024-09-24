using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IBL.IRepositoryBL _ibl;

        public RepositoryController(IBL.IRepositoryBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/Repository
        [HttpGet]
        public ActionResult<IEnumerable<RepositoryDTO>> Get()
        {
            var repositoryes = _ibl.GetAll().ToList();
            return Ok(repositoryes);
        }

        // GET api/Repository/5
        [HttpGet("{id}")]
        public ActionResult<RepositoryDTO> Get(int id)
        {
            try
            {
                var repositoryDto = _ibl.Get(id);

                if (repositoryDto == null)
                {
                    return NotFound(); // מחזיר 404 אם המשתמש לא נמצא
                }

                return Ok(repositoryDto); // מחזיר 200 עם ה-RepositoryDTO שנמצא
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/Repository
        [HttpPost]
        public ActionResult Post([FromBody] RepositoryDTO repositoryDto)
        {
            if (repositoryDto == null)
            {
                return BadRequest("Repository cannot be null");
            }

            try
            {
                var success = _ibl.AddNew(repositoryDto);
                if (success)
                {
                    return CreatedAtAction(nameof(Get), new { id = repositoryDto.RepositoryId }, repositoryDto);
                }
                return StatusCode(500, "Failed to add new repository.");
            }
            catch (Exception ex)
            {
                // הוספת פרטי השגיאה לקובץ הלוג או למסוף
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/Repository/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RepositoryDTO repositoryDto)
        {
            if (repositoryDto == null || repositoryDto.RepositoryId != id)
            {
                return BadRequest("Repository ID mismatch");
            }

            var existingRepository = _ibl.Get(id);
            if (existingRepository == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(repositoryDto);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/Repository/5
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