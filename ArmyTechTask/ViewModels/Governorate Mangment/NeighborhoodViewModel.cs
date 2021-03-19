using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.ViewModels
{
    public class NeighborhoodViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Governorate { get; set; }

        

    }
}