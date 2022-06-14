using Domain.Agilis.DTOs.User;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByIdUser(int id)
        {
            try
            {
                return Ok(_userService.GetByIdUser(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserInsertDTO userInsertDTO)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.Created, _userService.InsertUser(userInsertDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            try
            {
                return Ok(_userService.UpdateUser(userUpdateDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok(new { message = $"User id: {id} deletado com successo" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        // Montar o de login
    }
}
