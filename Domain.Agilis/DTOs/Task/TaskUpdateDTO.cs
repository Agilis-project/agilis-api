using Domain.Agilis.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.Task
{
    public class TaskUpdateDTO
    {
        [Required(ErrorMessage = "IdTask required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "NameTask required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DescriptionTask required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "TaskNumber required")]
        public string TaskNumber { get; set; }

        [Required(ErrorMessage = "StatusTask required")]
        public EStatusTask Status { get; set; }

        [Required(ErrorMessage = "StartDateTask required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDateTask required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "ReleaseDateTask required")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "IdMember required")]
        public int IdMember { get; set; }

        [Required(ErrorMessage = "IdSprint required")]
        public int IdSprint { get; set; }
    }
}
