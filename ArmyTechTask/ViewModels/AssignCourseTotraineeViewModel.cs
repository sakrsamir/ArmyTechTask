using System;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.ViewModels
{
    public class AssignCourseTotraineeViewModel
    {
        [Required]
        public int Course { get; set; }

        [Required]
        public int CourseType { get; set; }
        public int TraineeId { get; set; }

        [Required]
        public DateTime CourseDate { get; set; }
        public string Notes { get; set; }
    }
}