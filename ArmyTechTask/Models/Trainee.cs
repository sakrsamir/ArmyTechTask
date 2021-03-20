using System;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GovernorateId { get; set; }

        public Governorate Governorate { get; set; }

        [Required]
        public int NeighborhoodId { get; set; }

        public Neighborhood Neighborhood { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

    }
}