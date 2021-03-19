using ArmyTechTask.Models;
using ArmyTechTask.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ArmyTechTask.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDBContext _context;
        public CoursesController()
        {
            _context = new ApplicationDBContext();
        }



        #region CourseType
        public ActionResult Index()
        {
            var viewmodel = new CourseHomeViewModel
            {
                NewModel = new CourseTypeViewModel(),
                Courses = _context.CourseTypes
                .Include(g=>g.Courses )
                .Select(g =>
                new CourseTypeViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Courses = g.Courses.Select(s => new CourseViewModel { Name = s.Name }).ToList()
                }).ToList()
            };
            return View(viewmodel);

        }
        public PartialViewResult _AddNewType()
        {
            return PartialView(new CourseTypeViewModel());
        }

        [HttpGet]
        public PartialViewResult _ListAll()
        {
            var courseTypes = _context.CourseTypes
                .Include(g => g.Courses)
                .Select(g =>
                new CourseTypeViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Courses = g.Courses.Select(s => new CourseViewModel { Name = s.Name }).ToList()
                }).ToList();
            return PartialView("_ListAll", courseTypes);
        }

        [HttpPost]
        public ActionResult _AddNewType(CourseTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json("0");

            var type = new CourseType
            {
                Name = viewModel.Name
            };
            _context.CourseTypes.Add(type);
            _context.SaveChanges();

            return RedirectToAction("_ListAll");
        }

        #endregion

        #region Course
        public ActionResult CreateCourse()
        {
            var lst = new SelectList(_context.CourseTypes, "Id", "Name");
            ViewBag.TypesLst = lst;


            var course = new CourseViewModel();

            return View(course);
        }
        [HttpPost]
        public ActionResult CreateCourse(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("CreateCourse");

            var course = new Course()
            {
                Name = viewModel.Name,
                CouseTypeId = viewModel.Type
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}