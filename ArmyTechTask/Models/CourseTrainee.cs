using System;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Models
{
    public class CourseTrainee
    {
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public int TraineeId { get; set; }

        public Trainee Trainee { get; set; }

        [Required]
        public DateTime CourseDate { get; set; }

        public string Notes { get; set; }
    }
}