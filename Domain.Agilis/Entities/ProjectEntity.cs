using System;
using System.Collections.Generic;

namespace Domain.Agilis.Entities
{
    public class ProjectEntity : EntityBase
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        #region Config EntityFramework
        public virtual ICollection<ProjectMemberEntity> ProjectMember { get; set; }

        public virtual ICollection<SprintEntity> Sptints { get; set; }
        #endregion
    }
}
