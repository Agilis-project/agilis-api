using Domain.Agilis.DTOs.Sprint;
using Domain.Agilis.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Agilis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SprintController : ControllerBase
    {
        private readonly ISprintService _sprintService;

        public SprintController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        [HttpGet]
        public IActionResult GetAllSprints()
        {
            try
            {
                return Ok(_sprintService.GetAllSprints());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByIdSprint(int id)
        {
            try
            {
                return Ok(_sprintService.GetByIdSprint(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Pode passar o start e end date nesse formato yyyy-mm-dd, ex: 2022-06-24
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/Sprint/Backlog/{id:int}")]
        public IActionResult GetSprintBacklog(int id)
        {
            try
            {
                return Ok(_sprintService.GetSprintBacklog(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtém todas as sprints do id de projeto que for passado como parâmetro, menos a Backlog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/Sprint/Project/{id:int}")]
        public IActionResult GetAllSprintsByIdProject(int id)
        {
            try
            {
                return Ok(_sprintService.GetAllSprintsByIdProject(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult InsertSprint([FromBody] SprintInsertDTO sprintInsertDTO)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.Created, _sprintService.InsertSprint(sprintInsertDTO));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateSprint([FromBody] SprintUpdateDTO sprintUpdateDTO)
        {
            try
            {
                return Ok(_sprintService.UpdateSprint(sprintUpdateDTO));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteSprint(int id)
        {
            try
            {
                _sprintService.DeleteSprint(id);
                return Ok(new { message = $"Sprint id: {id} deletado com successo" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
