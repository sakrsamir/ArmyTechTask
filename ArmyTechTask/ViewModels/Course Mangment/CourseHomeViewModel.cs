using System.Collections.Generic;

namespace ArmyTechTask.ViewModels
{
    public class CourseHomeViewModel
    {
        public CourseTypeViewModel NewModel { get; set; }
        public IEnumerable<CourseTypeViewModel> Courses { get; set; }
    }
}