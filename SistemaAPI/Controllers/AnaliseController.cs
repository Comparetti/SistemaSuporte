using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuporteCore.Entity;
using SuporteCore.Entity.DTO;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;

namespace SistemaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliseController : ControllerBase
    {

        private readonly IAnaliseService _analiseService;
        private readonly IAnaliseRepository _analiseRepository;
        private readonly IMapper _mapper;
        public AnaliseController(IAnaliseService analiseService, IAnaliseRepository analiseRepository, IMapper mapper)
        {
            _analiseRepository = analiseRepository;
            _analiseService = analiseService;
            _mapper = mapper;
        }

        // GET: api/Analise
        [HttpGet("", Name = "IndexAnalise")]
        public IActionResult Index([FromQuery]UrlQuery urlQuery)
        {
            var item = _analiseService.QueryPag(urlQuery);
            if (_analiseService.QueryPag(urlQuery).Results.Count == 0)
                return NotFound();
         //   ListPaginacao<AnaliseDTO> lst = CreateLinksAnalise(urlQuery, item);
            return Ok(item);
        }

        // GET: api/Analise/5
        [HttpGet("{id}", Name = "GetIdAnalise")]
        public IActionResult Get(int? id)
        {
            if (id == null)
                return NotFound();
            var analise = _analiseRepository.GetById(id);
            #region LINK
            AnaliseDTO analiseDTO = _mapper.Map<Analise, AnaliseDTO>(analise);
            analiseDTO.Links.Add(
                new LinkDTO("self", Url.Link("GetId", new { id = analise.AnaliseId }), "GET"));
            analiseDTO.Links.Add(
                new LinkDTO("update", Url.Link("GetId", new { id = analise.AnaliseId }), ""));
            analiseDTO.Links.Add(
                new LinkDTO("delete", Url.Link("GetId", new { id = analise.AnaliseId }), ""));
            #endregion
            return Ok(analiseDTO);
        }

        // POST: api/Analise
        [HttpPost]
        public IActionResult Post([FromBody] Analise analise)
        {
            _analiseRepository.UppAnaise(analise);

            AnaliseDTO analiseDTO = _mapper.Map<Analise, AnaliseDTO>(analise);
            analiseDTO.Links.Add(
                new LinkDTO("self", Url.Link("GetId", new { id = analiseDTO.PhoebusId }), "GET"));
            return Created($"/api/Analise/{analiseDTO.AnaliseId}", analiseDTO);

        }

        // PUT: api/Analise/5
        [HttpPut("{id}", Name = "UppAnalise")]
        public IActionResult Put(int id, [FromBody] Analise analise)
        {
            if (_analiseRepository.GetById(id) == null)
                return NotFound();
            if (analise == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            analise.AnaliseId = id;
            _analiseRepository.UppAnaise(analise);

            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteIdAnalise")]
        public IActionResult Delete(int id)
        {
            var analise = _analiseRepository.GetById(id);
            _analiseRepository.Delete(analise);
            return Ok();

        }
        #region Create Link Analise
        private ListPaginacao<AnaliseDTO> CreateLinksAnalise(UrlQuery urlQuery, ListPaginacao<Analise> item)
        {
            var lista = _mapper.Map<ListPaginacao<Analise>, ListPaginacao<AnaliseDTO>>(item);

            
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
