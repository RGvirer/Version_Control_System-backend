using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IBL.IVersionBL _ibl;

        public VersionController(IBL.IVersionBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/Version
        [HttpGet]
        public ActionResult<IEnumerable<VersionDTO>> Get()
        {
            var versiones = _ibl.GetAll().ToList();
            return Ok(versiones);
        }

        // GET api/Version/5
        [HttpGet("{id}")]
        public ActionResult<VersionDTO> Get(int id)
        {
            try
            {
                var versionDto = _ibl.Get(id);

                if (versionDto == null)
                {
                    return NotFound(); // מחזיר 404 אם המשתמש לא נמצא
                }

                return Ok(versionDto); // מחזיר 200 עם ה-VersionDTO שנמצא
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/Version
        [HttpPost]
        public ActionResult Post([FromBody] VersionDTO versionDto)
        {
            if (versionDto == null)
            {
                return BadRequest("Version cannot be null");
            }

            try
            {
                var success = _ibl.AddNew(versionDto);
                if (success)
                {
                    return CreatedAtAction(nameof(Get), new { id = versionDto.VersionId }, versionDto);
                }
                return StatusCode(500, "Failed to add new version.");
            }
            catch (Exception ex)
            {
                // הוספת פרטי השגיאה לקובץ הלוג או למסוף
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/Version/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VersionDTO versionDto)
        {
            if (versionDto == null || versionDto.VersionId != id)
            {
                return BadRequest("Version ID mismatch");
            }

            var existingVersion = _ibl.Get(id);
            if (existingVersion == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(versionDto);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/Version/5
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