using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.Enums
{
    public enum EStatusTask
    {
        [Display(Name = "Backlog")]
        Backlog = 1,

        [Display(Name = "TODO")]
        TODO = 2,

        [Display(Name = "In Progress")]
        InProgress = 3,
        
        [Display(Name = "Done")]
        Done = 4,

        [Display(Name = "Block")]
        Block = 5,

        [Display(Name = "Bug")]
        Bug = 6
    }
}
