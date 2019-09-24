using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuporteCore.Entity;
using SuporteCore.Entity.DTO;
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
        private readonly IMapper _mapper;



        public PhoebusController(IPhoebusRepository context, IPhoebusService phoebusService, IMapper mapper)
        {
            _phoebusService = phoebusService;
            _mapper = mapper;
            _PhRespository = context;
        }

        [HttpGet("", Name = "Index")]
        public IActionResult Index([FromQuery]UrlQuery urlQuery)
        {
            var item = _phoebusService.PhQueryPag(urlQuery);

            if (item.Results.Count == 0)
                return NotFound();

            ListPaginacao<PhoebusDTO> lista = CreateLinksPhoebus(urlQuery, item);
            return Ok(lista);
        }



        // GET: api/Phoebus/5
        [HttpGet("{Id}", Name = "GetId")]
        public IActionResult Get(int? Id)
        {
            var ph = _PhRespository.GetById(Id);

            PhoebusDTO phoebusDTO = _mapper.Map<Phoebus, PhoebusDTO>(ph);

            phoebusDTO.Links.Add(
            new LinkDTO("self", Url.Link("GetId", new { id = phoebusDTO.PhoebusId }), "GET")
            );
            phoebusDTO.Links.Add(
            new LinkDTO("update", Url.Link("UppPhoebus", new { id = phoebusDTO.PhoebusId }), "PUT")
            );
            phoebusDTO.Links.Add(
            new LinkDTO("delete", Url.Link("DeleteId", new { id = phoebusDTO.PhoebusId }), "DELETE")
            );

            return Ok(phoebusDTO);
        }

        // POST: api/Phoebus
        [HttpPost]
        public IActionResult Post([FromBody] Phoebus phoebus)
        {
            _PhRespository.UpdatePhoebus(phoebus);

            PhoebusDTO phoebusDTO = _mapper.Map<Phoebus, PhoebusDTO>(phoebus);
            phoebusDTO.Links.Add(
                new LinkDTO("self", Url.Link("GetId", new { id = phoebusDTO.PhoebusId }), "GET"));
            return Created($"/api/Phoebus/{phoebusDTO.PhoebusId}", phoebusDTO);
        }

        // PUT: api/Phoebus/5
        [HttpPut("{id}", Name = "UppPhoebus")]
        public IActionResult Put(int id, [FromBody] Phoebus ph)
        {
            if (_PhRespository.GetById(id) == null)
                return NotFound();

            if (ph == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ph.PhoebusId = id;
            _PhRespository.UpdatePhoebus(ph);

            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteId")]
        public IActionResult Delete(int id)
        {
            var ph = _PhRespository.GetById(id);
            _PhRespository.Delete(ph);
            return Ok();
        }

        #region Create Link Phoebus
        private ListPaginacao<PhoebusDTO> CreateLinksPhoebus(UrlQuery urlQuery, ListPaginacao<Phoebus> item)
        {
            var lista = _mapper.Map<ListPaginacao<Phoebus>, ListPaginacao<PhoebusDTO>>(item);

            foreach (var ph in lista.Results)
            {
                ph.Links = new List<LinkDTO>();
                ph.Links.Add(new LinkDTO("self", Url.Link("GetId", new { id = ph.PhoebusId }), "GET"));
            }

            lista.Links.Add(new LinkDTO("self", Url.Link("Index", urlQuery), "GET"));

            if (item.Paginacao != null)
            {
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(item.Paginacao));

                if (urlQuery.PagNumero + 1 <= item.Paginacao.TotalPaginas)
                {
                    var queryString = new UrlQuery() { PagNumero = urlQuery.PagNumero + 1, PagRegistro = urlQuery.PagRegistro };
                    lista.Links.Add(new LinkDTO("next", Url.Link("Index", queryString), "GET"));
                }

                if (urlQuery.PagNumero - 1 > 0)
                {
                    var queryString = new UrlQuery() { PagNumero = urlQuery.PagNumero - 1, PagRegistro = urlQuery.PagRegistro };
                    lista.Links.Add(new LinkDTO("prev", Url.Link("Index", queryString), "GET"));
                }
            }

            return lista;
        }
        #endregion
    }
}
