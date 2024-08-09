using DAL;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IBL.IDepartmentBL _ibl;

        public DepartmentController(IBL.IDepartmentBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/Department
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> Get()
        {
            var departments = _ibl.GetAll().ToList();
            return Ok(departments);
        }

        // GET api/Department/5
        [HttpGet("{id}")]
        public ActionResult<DepartmentDTO> Get(int id)
        {
            try
            {
                var departmentDto = _ibl.Get(id);

                if (departmentDto == null)
                {
                    return NotFound();
                }

                return Ok(departmentDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/Department
        [HttpPost]
        public ActionResult Post([FromBody] DepartmentDTO departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest("Department cannot be null");
            }

            var success = _ibl.AddNew(departmentDto);
            if (success)
            {
                return CreatedAtAction(nameof(Get), new { id = departmentDto.DepartmentId }, departmentDto);
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // PUT api/Department/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DepartmentDTO departmentDto)
        {
            if (departmentDto == null || departmentDto.DepartmentId != id)
            {
                return BadRequest("Department ID mismatch");
            }

            var existingDepartment = _ibl.Get(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(departmentDto);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/Department/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingDepartment = _ibl.Get(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            var success = _ibl.Delete(existingDepartment);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }
    }
}
