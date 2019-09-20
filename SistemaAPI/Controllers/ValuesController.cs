using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaInfra.Data;
using SuporteCore.Interfaces.Service;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SuporteContext _context;
        private readonly IPhoebusService _phoebusService;

        public ValuesController(SuporteContext context, IPhoebusService phoebusService)
        {
            _phoebusService = phoebusService;
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_context.Phoebus);
        }
        [Route("api/ObterTodos")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos()
        {
            return Ok(_context.Phoebus.FirstOrDefault());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
