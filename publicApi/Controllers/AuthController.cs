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

        [HttpGet]
        [Route("register")]
        public async Task<ActionResult<JwtAuthResult>> Register()
        {
            if (!Request.Headers.ContainsKey("Authentication"))
            {
                return BadRequest();
            }
            string encodedAuthetication = Request.Headers["Authentication"];
            var registerData = Encoding_helper.DecodeFromBase64<usuarioDto>(encodedAuthetication);
            try
            {
                await _servicio.Register(registerData);
                var result = await _servicio.Authenticate(registerData.userName, registerData.password);
                return Ok(result);

            }
            catch (Exception er) {
                return BadRequest();
            }
           
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

        [HttpGet]
        [Route("VerifyDupUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<usuarioDto>> VerifyDup()
        {
            if (!Request.Headers.ContainsKey("Authentication"))
            {
                return BadRequest();
            }
            string encodedAuthetication = Request.Headers["Authentication"];
            var username = Encoding_helper.DecodeFromBase64<string>(encodedAuthetication);

            if (string.IsNullOrEmpty(username)) return BadRequest();

            var user = await _servicio.verifyDupUser(username);

            return Ok(user);
        }
    }
}
