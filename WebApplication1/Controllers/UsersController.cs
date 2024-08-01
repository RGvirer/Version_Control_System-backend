using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_18_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBL.IUserBL ibl;

        public UserController(IBL.IUserBL ibl)
        {
            this.ibl = ibl;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return ibl.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public bool Post([FromBody] object item)
        {
            return ibl.AddNew(item);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}