using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.Enums
{
    public enum ERoleUser
    {
        [Display(Name = "Standart")]
        Standart = 1,

        [Display(Name = "Manager")]
        Manager = 2,

        [Display(Name = "Owner")]
        Owner = 3
    }
}
