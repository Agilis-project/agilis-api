using Domain.Agilis.DTOs.Task;
using Domain.Agilis.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace API.Agilis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            try
            {
                return Ok(_taskService.GetAllTasks());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByIdTask(int id)
        {
            try
            {
                return Ok(_taskService.GetByIdTask(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult InsertTask([FromBody] TaskInsertDTO taskInsertDTO)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.Created, _taskService.InsertTask(taskInsertDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateTask([FromBody] TaskUpdateDTO taskUpdateDTO)
        {
            try
            {
                return Ok(_taskService.UpdateTask(taskUpdateDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok(new { message = $"Task id: {id} deletado com successo" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
