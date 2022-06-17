using Domain.Agilis.DTOs.Member;
using Domain.Agilis.Enums;
using System.Collections.Generic;

namespace Domain.Agilis.DTOs.User
{
    public class UserOutputDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public ERoleUser Role { get; set; }

        public List<MemberOutputDTO> Members { get; set; }

        public bool Active { get; set; }
    }
}
