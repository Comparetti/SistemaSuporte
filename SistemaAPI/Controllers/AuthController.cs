using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistemaInfra.Data;
using SuporteCore.Entity.DTO;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SuporteContext _context;
        private readonly IPhoebusService _phoebusService;

        private readonly SignInManager<IdentityUser> _singnInManeger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;


        public AuthController(SuporteContext context,
                              IPhoebusService phoebusService,
                              IOptions<AppSettings> appSettings,
                              UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            _phoebusService = phoebusService;
            _context = context;
            _singnInManeger = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("new-user")]
        public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser
            {
                UserName = registerUserDTO.Email,
                Email = registerUserDTO.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _singnInManeger.SignInAsync(user, false);

            return Ok(await GerarJWT(registerUserDTO.Email));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Register([FromBody]LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser { UserName = loginUserDTO.Email };

            var result = await _singnInManeger.PasswordSignInAsync(loginUserDTO.Email, loginUserDTO.Password, false, true);

            if (result.Succeeded)
                return Ok(await GerarJWT(loginUserDTO.Email));

            return BadRequest("Usuário ou senha inválido");
        }

        private async Task<string> GerarJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
