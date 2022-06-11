using Domain.Agilis.Enums;
using System.Collections.Generic;

namespace Domain.Agilis.Entities
{
    public class MemberEntity : EntityBase
    {
        public string Name { get; set; }

        public ERole Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        #region Config EntityFramework
        public virtual ICollection<ProjectMemberEntity> ProjectMember { get; set; }

        public virtual ICollection<TaskEntity> Tasks { get; set; }
        #endregion
    }
}
