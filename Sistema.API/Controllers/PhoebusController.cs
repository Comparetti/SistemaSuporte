using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Service;

namespace Sistema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoebusController : ControllerBase
    {
        private readonly SuporteContext _context;
        private readonly IPhoebusService _phoebusService;

        public PhoebusController(SuporteContext context, IPhoebusService phoebusService)
        {
            _phoebusService = phoebusService;
            _context = context;
        }
        // GET: api/Phoebus
        [HttpGet]
        public IEnumerable<Phoebus> Get()
        {
            return _phoebusService.GetAll();
        }

        // GET: api/Phoebus/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Phoebus
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Phoebus/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
