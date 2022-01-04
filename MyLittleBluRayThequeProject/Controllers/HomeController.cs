using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;
using System.Diagnostics;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BluRayRepository brRepository;
        private readonly PersonneRepository persRepository;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brRepository = new BluRayRepository();
            persRepository = new PersonneRepository();

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
            model.Langues = persRepository.GetListeLangues();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditBluRay(Models.BluRayInsertViewModel bluRayInsertViewModel)
        {
            brRepository.AddBluRay(BluRayInsertViewModel.ToDTO(bluRayInsertViewModel));

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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}