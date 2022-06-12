using Domain.Agilis.Enums;
using System.Collections.Generic;

namespace Domain.Agilis.Entities
{
    public class UserEntity : EntityBase
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ERoleUser Role { get; set; }

        #region Config EntityFramework
        public virtual ICollection<MemberEntity> Members { get; set; }
        #endregion
    }
}
