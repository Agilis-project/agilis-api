using System.Collections.Generic;

namespace Domain.Agilis.Entities
{
    public class MemberEntity : EntityBase
    {
        public string Name { get; set; }

        public int IdUser { get; set; }


        #region Config EntityFramework
        public virtual ICollection<ProjectMemberEntity> ProjectMember { get; set; }

        public virtual ICollection<TaskEntity> Tasks { get; set; }

        public virtual UserEntity User { get; set; }
        #endregion
    }
}
