using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Models
{
    public class CourseType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}