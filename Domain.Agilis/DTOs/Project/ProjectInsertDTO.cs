using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.Project
{
    public class ProjectInsertDTO
    {
        [Required(ErrorMessage = "NameProject required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "StarDateProject required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDateProject required")]
        public DateTime EndDate { get; set; }
    }
}
