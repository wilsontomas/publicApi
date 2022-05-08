using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using System.Threading.Tasks;
using publicApi.Service;
using publicApi.Service.Interfaces;
using System;

namespace publicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _servicio;
        public AuthController(IAuthService authService) 
        { 
            _servicio = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(usuarioDto user)
        {
            if (user == null) return BadRequest();
            try
            {
                await _servicio.Register(user);
            }
            catch (Exception er) {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<bool> login(string username,string password) 
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return BadRequest();

          var result = _servicio.Authenticate(username, password);
            return Ok(result);
        }
    }
}
