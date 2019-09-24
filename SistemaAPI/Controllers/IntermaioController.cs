using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class IntermaioController : ControllerBase
    {

        private readonly IIntermeioService _intService;
        private readonly IIntermeioRepository _intRepository;
        private readonly IMapper _mapper;
        public IntermaioController(IIntermeioRepository context, IIntermeioService intermeioService, IMapper mapper)
        {
            _intService = intermeioService;
            _mapper = mapper;
            _intRepository = context;
        }
        // GET: api/Intermaio
        [HttpGet("", Name = "Index")]
        public IActionResult Index([FromQuery]UrlQuery urlQuery)
        {
            var item = _intService.QueryPag(urlQuery);

            if (item.Results.Count == 0)
                return NotFound();

            ListPaginacao<IntermeioDTO> lst = CreateLinksIntermeio(urlQuery, item);
            return Ok(lst);
        }

        // GET: api/Intermaio/5
        [HttpGet("{id}", Name = "GetId")]
        public IActionResult Get(int? id)
        {
            var inter = _intRepository.GetById(id);

            IntermeioDTO intermeioDTO = _mapper.Map<Intermeio, IntermeioDTO>(inter);

            intermeioDTO.Links.Add(
                new LinkDTO("self", Url.Link("GetId", new { id = intermeioDTO.IntermeioId }), "GET"));

            return Ok(intermeioDTO);
        }
        #region Create Link Intermeio
        private ListPaginacao<IntermeioDTO> CreateLinksIntermeio(UrlQuery urlQuery, ListPaginacao<Intermeio> item)
        {
            var lista = _mapper.Map<ListPaginacao<Intermeio>, ListPaginacao<IntermeioDTO>>(item);

            foreach (var ph in lista.Results)
            {
                ph.Links = new List<LinkDTO>();
                ph.Links.Add(new LinkDTO("self", Url.Link("GetId", new { id = ph.IntermeioId }), "GET"));
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
