using Domain.Agilis.DTOs.Project;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                return Ok(_projectService.GetAllProjects());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBytIdProject(int id)
        {
            try
            {
                return Ok(_projectService.GetByIdProject(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult InsertProject([FromBody] ProjectInsertDTO projectInsertDTO)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.Created, _projectService.InsertProject(projectInsertDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateProject([FromBody] ProjectUpdateDTO projectUpdateDTO)
        {
            try
            {
                return Ok(_projectService.UpdateProject(projectUpdateDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _projectService.DeleteProject(id);
                return Ok(new { message = $"Project id: {id} deletado com successo" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}