using System.Collections.Generic;

namespace ArmyTechTask.ViewModels
{
    public class GovernorateHomeViewModel
    {
        public GovernorateViewModel NewModel { get; set; }
        public IEnumerable<GovernorateViewModel> Governorates { get; set; }
    }
}