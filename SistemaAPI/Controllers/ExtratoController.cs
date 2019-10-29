using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : ControllerBase
    {
        private readonly IExtratoRepository _extratoRepository;
        private readonly IExtratoService _extratoService;

        public ExtratoController(IExtratoRepository extratoRepository, IExtratoService extratoService )
        {
            _extratoRepository = extratoRepository;
            _extratoService = extratoService;
        }

        // GET: api/Extrato
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_extratoRepository.GetAllExtratoByPos());
        }
        // POST: api/Extrato
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Extrato/5
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
