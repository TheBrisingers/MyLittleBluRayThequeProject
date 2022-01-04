using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;
using MyLittleBluRayThequeProject.Business;
using System.Diagnostics;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BluRayRepository brRepository;
        private readonly PersonneRepository persRepository;
        private readonly LangueRepository langRepository;
        private readonly BluRayBusiness bluRayBusiness;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brRepository = new BluRayRepository();
            bluRayBusiness = new BluRayBusiness();
            persRepository = new PersonneRepository();
            langRepository = new LangueRepository();

        }

        /*public IActionResult AllBluRay()
        {
            IndexViewModel model = new IndexViewModel();
            model.BluRays = brRepository.GetListeBluRay();
            return View(model);
        }*/

        public IActionResult AllBluRay(long? id)
        {
            IndexViewModel model = new IndexViewModel();
            model.BluRays = brRepository.GetListeBluRay();
            if(id != null)
            {
                model.SelectedBluRay = model.BluRays.FirstOrDefault(x => x.Id == id);
            }
            return View(model);
        }

        public IActionResult InsertBluRay()
        {
            IndexViewModel model = new IndexViewModel();
            model.Personnes = persRepository.GetListePersonne();
            model.Langues = langRepository.GetListeLangues();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditBluRay(Models.BluRayInsertViewModel bluRayInsertViewModel)
        {
            bluRayBusiness.AddBluRay(BluRayInsertViewModel.ToDTO(bluRayInsertViewModel));

            IndexViewModel model = new IndexViewModel();
            model.BluRays = brRepository.GetListeBluRay();
            return View("AllBluRay", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InsertPersonne()
        {
            IndexViewModel model = new IndexViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPersonne(Models.PersonneInsertViewModel personneInsertViewModel)
        {
            persRepository.AddPersonne(PersonneInsertViewModel.ToDTO(personneInsertViewModel));

            IndexViewModel model = new IndexViewModel();
            model.Personnes = persRepository.GetListePersonne();
            model.BluRays = brRepository.GetListeBluRay();
            return View("AllBluRay", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}