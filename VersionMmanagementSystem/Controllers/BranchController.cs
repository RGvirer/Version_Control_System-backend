using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBL.IBranchBL _ibl;

        public BranchController(IBL.IBranchBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/Branch
        [HttpGet]
        public ActionResult<IEnumerable<BranchDTO>> Get()
        {
            var branchs = _ibl.GetAll().ToList();
            return Ok(branchs);
        }

        // GET api/Branch/5
        [HttpGet("{id}")]
        public ActionResult<BranchDTO> Get(int id)
        {
            try
            {
                var branchDto = _ibl.Get(id);

                if (branchDto == null)
                {
                    return NotFound(); // מחזיר 404 אם המשתמש לא נמצא
                }

                return Ok(branchDto); // מחזיר 200 עם ה-BranchDTO שנמצא
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/Branch
        [HttpPost]
        public ActionResult Post([FromBody] BranchDTO branchDto)
        {
            if (branchDto == null)
            {
                return BadRequest("Branch cannot be null");
            }

            try
            {
                var success = _ibl.AddNew(branchDto);
                if (success)
                {
                    return CreatedAtAction(nameof(Get), new { id = branchDto.BranchId }, branchDto);
                }
                return StatusCode(500, "Failed to add new branch.");
            }
            catch (Exception ex)
            {
                // הוספת פרטי השגיאה לקובץ הלוג או למסוף
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/Branch/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BranchDTO branchDto)
        {
            if (branchDto == null || branchDto.BranchId != id)
            {
                return BadRequest("Branch ID mismatch");
            }

            var existingBranch = _ibl.Get(id);
            if (existingBranch == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(branchDto);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/Branch/5
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