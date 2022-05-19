using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using System.Threading.Tasks;
using publicApi.Service;
using publicApi.Service.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;
using publicApi.Service.UtilClasses;
using publicApi.Services.Helpers;

namespace publicApi.Controllers
{
    [AllowAnonymous]
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

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<JwtAuthResult>> login() 
        {
            if (!Request.Headers.ContainsKey("Authentication"))
            {
                return BadRequest();
            }
            string encodedAuthetication = Request.Headers["Authentication"];
            var loginData = Encoding_helper.DecodeFromBase64<loginData>(encodedAuthetication);


            if (string.IsNullOrEmpty(loginData.username) || string.IsNullOrEmpty(loginData.password)) return BadRequest();

          var result =  await _servicio.Authenticate(loginData.username, loginData.password);
            return Ok(result);
        }
    }
}
