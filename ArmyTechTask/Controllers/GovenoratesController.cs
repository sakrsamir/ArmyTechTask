using ArmyTechTask.Models;
using ArmyTechTask.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ArmyTechTask.Controllers
{
    public class GovenoratesController : Controller
    {
        private readonly ApplicationDBContext _context;
        public GovenoratesController()
        {
            _context = new ApplicationDBContext();
        }



        #region Govenorate
        public ActionResult Index()
        {
            var viewmodel = new GovernorateHomeViewModel
            {
                NewModel = new GovernorateViewModel(),
                Governorates = _context.Governorates
                .Include(g => g.Neighborhoods)
                .Select(g =>
                new GovernorateViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Neighborhoods = g.Neighborhoods.Select(s => new NeighborhoodViewModel { Name = s.Name }).ToList()
                }).ToList()
            };
            return View(viewmodel);
           
        }
        public PartialViewResult _AddNewGov()
        {
            return PartialView(new GovernorateViewModel());
        }

        [HttpGet]
        public PartialViewResult _ListAll()
        {
            var govs = _context.Governorates
                .Include(g => g.Neighborhoods)
                .Select(g =>
                new GovernorateViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Neighborhoods = g.Neighborhoods.Select(s => new NeighborhoodViewModel { Name = s.Name }).ToList()
                }).ToList();
            return PartialView("_ListAll", govs);
        }

        [HttpPost]
        public ActionResult _AddNewGov(GovernorateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json("0");

            var gov = new Governorate
            {
                Name = viewModel.Name
            };
            _context.Governorates.Add(gov);
            _context.SaveChanges();
            return RedirectToAction("_ListAll");
        }

        #endregion

        #region Neighborhood
        public ActionResult CreateNeighborhood()
        {
            var lst = new SelectList(_context.Governorates, "Id", "Name");
            ViewBag.govLst = lst;


            var Neighborhood = new NeighborhoodViewModel();

            return View(Neighborhood);
        }
        [HttpPost]
        public ActionResult CreateNeighborhood(NeighborhoodViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("CreateNeighborhood");

            var neighborhood = new Neighborhood()
            {
                Name=viewModel.Name,
                GovernorateId=viewModel.Governorate
            };
            _context.Neighborhoods.Add(neighborhood);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}