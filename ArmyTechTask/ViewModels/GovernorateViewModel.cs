using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.ViewModels
{
    public class GovernorateViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public IEnumerable<NeighborhoodViewModel> Neighborhoods { get; set; }
        public GovernorateViewModel()
        {

        }
    }
}