using System;
using System.Collections.Generic;

namespace ArmyTechTask.ViewModels
{
    public class TraineeCourseHome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

    }
}