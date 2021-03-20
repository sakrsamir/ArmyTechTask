using ArmyTechTask.Models;
using ArmyTechTask.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ArmyTechTask.Controllers
{
    public class TranieesController : Controller
    {
        private readonly ApplicationDBContext _context;
        public TranieesController()
        {
            _context = new ApplicationDBContext();
        }
        #region Trainee
        // GET: Student
        public ActionResult Index()
        {
            List<SelectListItem> Govs = new List<SelectListItem>();
            List<SelectListItem> Nieghs = new List<SelectListItem>();
            Govs = _context.Governorates.Select(g=> new SelectListItem { Text=g.Name,Value=g.Id.ToString()}).ToList();
            var def = new SelectListItem()
            {
                Value = "",
                Text = "--- select Gov ---"
            };
            Govs.Insert(0, def);
            ViewBag.Govs = Govs;
            Nieghs.Insert(0, def);
            ViewBag.Neighborhoods = Nieghs;

            var trainees = _context.Trainees
                .Select(t =>
                new TraineeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList();
            return View(trainees);
        }

        public JsonResult PopulateNigh(int govId)
        {
            List<SelectListItem> Nieghs = new List<SelectListItem>();
            Nieghs = _context.Neighborhoods
                    .Where(n => n.GovernorateId == govId)
                    .Select(g =>
                    new SelectListItem
                    {
                        Text = g.Name,
                        Value = g.Id.ToString()
                    }).ToList();
            return Json(Nieghs,JsonRequestBehavior.AllowGet);
        }
        
        
        [HttpPost]
        public ActionResult AddNewTrainee(TraineeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json("0");

            var trainee = new Trainee
            {
                Name = viewModel.Name,
                GovernorateId = viewModel.Governorate,
                NeighborhoodId = viewModel.Neighborhood,
                BirthDate = viewModel.BirthDate,
                Address=viewModel.Address

            };
            _context.Trainees.Add(trainee);
            _context.SaveChanges();

            return RedirectToAction("_ListAll");
        }

        public PartialViewResult _ListAll(string searchTerm = "")
        {
            var trainees = _context.Trainees
                .Where(n=>n.Name.Contains(searchTerm))
                .Select(t=>
                new TraineeViewModel {
                    Id =t.Id,
                    Name =t.Name
                }).ToList();

            return PartialView("_ListAll", trainees);
        }


        #endregion

        #region AssignCourseToTrainee

        public ActionResult ShowProfile(int Id = 0)
        {
            if (Id == 0)
                return RedirectToAction("Index");

            List<SelectListItem> CoursesTypes = new List<SelectListItem>();
            List<SelectListItem> Courses = new List<SelectListItem>();
            CoursesTypes = _context.CourseTypes.Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() }).ToList();
            var def = new SelectListItem()
            {
                Value = "",
                Text = "--- select CourseType ---"
            };
            CoursesTypes.Insert(0, def);
            ViewBag.CoursesTypes = CoursesTypes;
            Courses.Insert(0, def);
            ViewBag.Courses = Courses;

            var trainee = _context.Trainees.FirstOrDefault(t => t.Id == Id);
            if (trainee != null)
            {
                var traineeHome = new TraineeCourseHome
                {
                    Id = trainee.Id,
                    Name = trainee.Name,
                    BirthDate = trainee.BirthDate,
                    Address = trainee.Address,
                    Courses = _context.CourseTrainees.Where(s => s.TraineeId == trainee.Id).Select(g => new CourseViewModel { Name = g.Course.Name, TypeName = g.Course.CouseType.Name, SatrtDate = g.CourseDate })
                };
                ShowProfileViewModel viewmodel = new ShowProfileViewModel
                {
                    assignCourseTotraineeView = new AssignCourseTotraineeViewModel { TraineeId=Id },
                    traineeCourseHome = traineeHome
                };
                return View(viewmodel);
            }
            return RedirectToAction("Index");
        }
        public JsonResult PopulateCourses(int typeId)
        {
            List<SelectListItem> courses = new List<SelectListItem>();
            courses = _context.Courses
                    .Where(n => n.CouseTypeId == typeId)
                    .Select(g =>
                    new SelectListItem
                    {
                        Text = g.Name,
                        Value = g.Id.ToString()
                    }).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignCourseToTrainee(AssignCourseTotraineeViewModel viewModel)
        {
            var coursetrain = new CourseTrainee
            {
                CourseId = viewModel.Course,
                TraineeId = viewModel.TraineeId,
                CourseDate = viewModel.CourseDate,
                Notes = viewModel.Notes
            };
            _context.CourseTrainees.Add(coursetrain);
            _context.SaveChanges();

            return RedirectToAction("_ShowBasicInfo",new { Id=viewModel.TraineeId});
        }
        public PartialViewResult _ShowBasicInfo(int Id)
        {
            var trainee = _context.Trainees.FirstOrDefault(t => t.Id == Id);
            
                var traineeHome = new TraineeCourseHome
                {
                    Id = trainee.Id,
                    Name = trainee.Name,
                    BirthDate = trainee.BirthDate,
                    Address = trainee.Address,
                    Courses = _context.CourseTrainees.Where(s => s.TraineeId == trainee.Id).Select(g => new CourseViewModel { Name = g.Course.Name, TypeName = g.Course.CouseType.Name, SatrtDate = g.CourseDate })
                };
                return PartialView("_ShowBasicInfo", traineeHome);     
        }
        #endregion
    }
}