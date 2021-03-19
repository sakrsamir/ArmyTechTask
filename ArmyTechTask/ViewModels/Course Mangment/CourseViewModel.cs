using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Type { get; set; }

        //public CourseTypeViewModel CouseType { get; set; }
    }
}