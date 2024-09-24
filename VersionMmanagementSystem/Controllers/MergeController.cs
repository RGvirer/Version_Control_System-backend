using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MergeController : ControllerBase
    {
        private readonly IBL.IMergeBL _ibl;

        public MergeController(IBL.IMergeBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/Merge
        [HttpGet]
        public ActionResult<IEnumerable<MergeDTO>> Get()
        {
            var mergees = _ibl.GetAll().ToList();
            return Ok(mergees);
        }

        // GET api/Merge/5
        [HttpGet("{id}")]
        public ActionResult<MergeDTO> Get(int id)
        {
            try
            {
                var mergeDto = _ibl.Get(id);

                if (mergeDto == null)
                {
                    return NotFound(); // מחזיר 404 אם המשתמש לא נמצא
                }

                return Ok(mergeDto); // מחזיר 200 עם ה-MergeDTO שנמצא
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/Merge
        [HttpPost]
        public ActionResult Post([FromBody] MergeDTO mergeDto)
        {
            if (mergeDto == null)
            {
                return BadRequest("Merge cannot be null");
            }

            try
            {
                var success = _ibl.AddNew(mergeDto);
                if (success)
                {
                    return CreatedAtAction(nameof(Get), new { id = mergeDto.MergeId }, mergeDto);
                }
                return StatusCode(500, "Failed to add new merge.");
            }
            catch (Exception ex)
            {
                // הוספת פרטי השגיאה לקובץ הלוג או למסוף
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/Merge/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MergeDTO mergeDto)
        {
            if (mergeDto == null || mergeDto.MergeId != id)
            {
                return BadRequest("Merge ID mismatch");
            }

            var existingMerge = _ibl.Get(id);
            if (existingMerge == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(mergeDto);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/Merge/5
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