using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publicApi.Model.Models;
using publicApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace publicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _servicio;
        public TaskController(ITaskService authService)
        {
            _servicio = authService;
        }

        [HttpGet]
        [Route("GetTasks/{id:Int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Tareas>>> GetAllTasks(int id)
        {
          var listado = await _servicio.GetTareas(id);
            return Ok(listado);
        }


        [HttpGet]
        [Route("GetTaskById/{id:Int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tareas>> AddTarea(int id)
        {
            var tarea = await _servicio.GetTareaById(id);
            return tarea;
        }

        [HttpPost]
        [Route("AddTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTaskById(Tareas tarea)
        {

            if (tarea == null) return BadRequest();
            await _servicio.addTarea(tarea);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTask(Tareas tarea)
        {

            if (tarea == null) return BadRequest();
            await _servicio.updateTarea(tarea);
            return Ok();
        }


    }
}
