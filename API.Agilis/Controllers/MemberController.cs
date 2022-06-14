using Domain.Agilis.DTOs.Member;
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
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            try
            {
                return Ok(_memberService.GetAllMembers());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByIdMember(int id)
        {
            try
            {
                return Ok(_memberService.GetByIdMember(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult InsertMember([FromBody] MemberInsertDTO memberInsertDTO)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.Created, _memberService.InsertMember(memberInsertDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateMember([FromBody] MemberUpdateDTO memberUpdateDTO)
        {
            try
            {
                return Ok(_memberService.UpdateMember(memberUpdateDTO));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMember(int id)
        {
            try
            {
                _memberService.DeleteMember(id);
                return Ok(new { message = $"Member id: {id} deletado com successo" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
