namespace Domain.Agilis.Entities
{
    public class ProjectMemberEntity : EntityBase
    {
        public int IdProject { get; set; }

        public int IdMember { get; set; }


        #region Config EntityFramework
        public virtual ProjectEntity Project { get; set; }

        public virtual MemberEntity Member { get; set; }
        #endregion
    }
}
