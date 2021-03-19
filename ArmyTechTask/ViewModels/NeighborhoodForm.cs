using System.Collections.Generic;

namespace ArmyTechTask.ViewModels
{
    public class NeighborhoodForm
    {
        public NeighborhoodViewModel Neighborhood { get; set; }
        public IEnumerable<GovernorateViewModel> governorates { get; set; }
         
    }
}