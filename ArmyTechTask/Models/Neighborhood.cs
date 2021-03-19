using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GovernorateId { get; set; }

        public Governorate Governorate { get; set; }

    }
}