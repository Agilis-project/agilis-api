using System;
using System.Collections.Generic;

namespace Domain.Agilis.Entities
{
    public class SprintEntity : EntityBase
    {
        public string Name { get; set; }

        public string SprintNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int IdProject { get; set; }


        #region Config EntityFramework
        public virtual ProjectEntity Project { get; set; }

        public virtual ICollection<TaskEntity> Tasks { get; set; }
        #endregion
    }
}
