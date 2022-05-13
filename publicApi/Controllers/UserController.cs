using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publicApi.Model.Models.Dtos;
using publicApi.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace publicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _servicio;
        public UserController(IUserService UserService)
        {
            _servicio = UserService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<usuarioDto>>> GetAllUsers()
        {
            var listado = await _servicio.getAllUsers();
            return listado;
        }


        [HttpGet]
        [Route("GetUserById/{id:Int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<usuarioDto>> GetUserById(int id)
        {
            var usuario = await _servicio.getUserInfo(id);
            return usuario;
        }

       

        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(usuarioDto user)
        {

            if (user == null) return BadRequest();
            await _servicio.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser/{id:Int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(int id)
        {

            if (id == 0) return BadRequest();
            await _servicio.DeleteUser(id);

            return Ok();
        }
    }
}
