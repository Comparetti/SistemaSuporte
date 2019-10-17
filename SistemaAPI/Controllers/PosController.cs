using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Service;

namespace SistemaAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PosController : ControllerBase
    {
        private readonly IPosRepository _posRepository;
        private readonly IPosService _posService;

        public PosController(IPosRepository posRepository, IPosService posService)
        {
            _posRepository = posRepository;
            _posService = posService;
        }
        // GET: api/Pos
        [HttpGet]
        public IActionResult Get()
        {
            _posService.RequestPosByIntermeio();
            return Ok(_posRepository.GetAll());
        }

        // GET: api/Pos/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_posRepository.GetById(id));
        }
    }
}
