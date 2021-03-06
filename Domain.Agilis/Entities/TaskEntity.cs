using Domain.Agilis.Enums;
using System;

namespace Domain.Agilis.Entities
{
    public class TaskEntity : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string TaskNumber { get; set; }

        public EStatusTask Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int IdMember { get; set; }

        public int IdSprint { get; set; }


        #region Config EntityFramework
        public virtual MemberEntity Member { get; set; }

        public virtual SprintEntity Sprint { get; set; }
        #endregion
    }
}
