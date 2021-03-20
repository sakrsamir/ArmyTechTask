using System;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.ViewModels
{
    public class CourseTraineeViewModel
    {
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        public CourseViewModel Course { get; set; }

        [Required]
        public int TraineeId { get; set; }

        public TraineeViewModel Trainee { get; set; }

        [Required]
        public DateTime CourseDate { get; set; }

        public string Notes { get; set; }
    }
}