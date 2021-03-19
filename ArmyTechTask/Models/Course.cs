using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int CouseTypeId { get; set; }

        public CourseType CouseType { get; set; }
    }
}