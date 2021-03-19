using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.ViewModels
{
    public class CourseTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}