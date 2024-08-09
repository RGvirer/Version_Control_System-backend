using DAL;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IBL.IPatientBL _ibl;

        public PatientController(IBL.IPatientBL ibl)
        {
            _ibl = ibl;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult<IEnumerable<PatientDTO>> Get()
        {
            var patients = _ibl.GetAll().ToList();
            return Ok(patients);
        }

        // GET api/Patient/5
        [HttpGet("{id}")]
        public ActionResult<PatientDTO> Get(int id)
        {
            try
            {
                var patientDto = _ibl.Get(id);

                if (patientDto == null)
                {
                    return NotFound();
                }

                return Ok(patientDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/Patient
        [HttpPost]
        public ActionResult Post([FromBody] PatientDTO patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Patient cannot be null");
            }

            var success = _ibl.AddNew(patientDto);
            if (success)
            {
                return CreatedAtAction(nameof(Get), new { id = patientDto.PatientId }, patientDto);
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // PUT api/Patient/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PatientDTO patientDto)
        {
            if (patientDto == null || patientDto.PatientId != id)
            {
                return BadRequest("Patient ID mismatch");
            }

            var existingPatient = _ibl.Get(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            var success = _ibl.Update(patientDto);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }

        // DELETE api/Patient/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingPatient = _ibl.Get(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            var success = _ibl.Delete(existingPatient);
            if (success)
            {
                return NoContent();
            }
            return StatusCode(500, "A problem occurred while handling your request.");
        }
    }
}
