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
        //public PartialViewResult _AddNewTrainee(TraineeViewModel viewModel)
        //{



        //    List<SelectListItem> Govs = new List<SelectListItem>();
        //    List<SelectListItem> Nieghs = new List<SelectListItem>();
        //    Govs = _context.Governorates.Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() }).ToList();

        //    if (viewModel.Governorate != 0)
        //    {
        //        Nieghs = _context.Neighborhoods
        //            .Where(n => n.GovernorateId == viewModel.Governorate)
        //            .Select(g =>
        //            new SelectListItem
        //            {
        //                Text = g.Name,
        //                Value = g.Id.ToString()
        //            }).ToList();


                

        //    }
        //    else
        //    {
        //        var firstGov = Convert.ToInt32(Govs[0].Value);
        //        Nieghs = _context.Neighborhoods
        //            .Where(n => n.GovernorateId == firstGov)
        //            .Select(g =>
        //            new SelectListItem
        //            {
        //                Text = g.Name,
        //                Value = g.Id.ToString()
        //            }).ToList();
        //    }

        //    ViewBag.Govs = Govs;
        //    ViewBag.Neighborhoods = Nieghs;

        //    return PartialView(viewModel);
        //}

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
    }
}