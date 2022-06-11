using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.Enums
{
    public enum ERole
    {
        [Display(Name = "Standart")]
        Standart = 1,

        [Display(Name = "Manager")]
        Manager = 2,

        [Display(Name = "Owner")]
        Owner = 3
    }
}
