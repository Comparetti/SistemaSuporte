using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoebusController : ControllerBase
    {
        private readonly IPhoebusRepository _PhRespository;
        private readonly IPhoebusService _phoebusService;
        

        public PhoebusController(IPhoebusRepository context, IPhoebusService phoebusService)
        {
            _phoebusService = phoebusService;
            _PhRespository = context;
        }
        // GET: api/Phoebus
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("Index")]
        [HttpGet]
        public IActionResult Index([FromQuery]PhoebusUrlQuery urlQuery)
        {
            var paginacao = _phoebusService.PhQueryPag(urlQuery);
            if (urlQuery.PagNumero.HasValue)
            {
                if (urlQuery.PagNumero > paginacao.Paginacao.TotalPaginas)
                    return NotFound();
            }
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginacao.Paginacao));
            return Ok(paginacao.ToList());  
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
