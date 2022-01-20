using MyLittleBluRayThequeProject.Repositories;
using MyLittleBluRayThequeProject.Business;
using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Models;
using System.Diagnostics;
using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Controllers
{

    public class EmpruntController : Controller
    {
        private readonly ILogger<EmpruntController> _logger;

        private readonly BluRayApiRepository brApiRepository;
        private readonly BluRayRepository brRepository;
        private readonly BluRayBusiness bluRayBusiness;

        public EmpruntController(ILogger<EmpruntController> logger)
        {
            _logger = logger;
            brApiRepository = new BluRayApiRepository();
            brRepository = new BluRayRepository();
            bluRayBusiness = new BluRayBusiness();
        }

        [HttpPost]
        public IActionResult EmpruntAllBluRay(EmpruntBodyViewModel empruntBodyViewModel)
        {
            IndexViewModel model = new IndexViewModel();
            model.LoueurBluRays = brApiRepository.GetBluRays(brApiRepository.GetLoueur(empruntBodyViewModel.IdLoueur).BaseUrl);
            if (empruntBodyViewModel.IdLoueur != null)
            {
                model.SelectedLoueurBluRays = model.LoueurBluRays.FirstOrDefault(x => x.Id == empruntBodyViewModel.IdLoueur);
                model.SelectedLoueur = new Loueur() { Id = empruntBodyViewModel.IdLoueur };
            }
            return View(model);
        }

        public IActionResult AllLoueur(long? id)
        {
            IndexViewModel model = new IndexViewModel();
            model.Loueurs = brApiRepository.GetListeLoueur();
            if (id != null)
            {
                model.SelectedLoueur = model.Loueurs.FirstOrDefault(x => x.Id == id);
            }
            return View(model);
        }

        [HttpPost("/BluRays/{IdBluray}/Emprunt")]
        public ObjectResult BorrowBluRay([FromRoute] IdBluRayRoute route)
        {
            try
            {
                if (brRepository.GetBluRay(route.IdBluray) != null)
                {
                    if (brRepository.GetBluRay(route.IdBluray).Disponible)
                    {
                        bluRayBusiness.BorrowBluRay(route.IdBluray);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return new CreatedResult($"{route.IdBluray}", null);
        }


        [HttpDelete("/BluRays/{IdBluray}/Emprunt")]
        public ObjectResult ReturnBluRay([FromRoute] IdBluRayRoute route)
        {
            try
            {
                if (brRepository.GetBluRay(route.IdBluray) != null)
                {
                    bluRayBusiness.ReturnBluRay(route.IdBluray);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return new CreatedResult($"{route.IdBluray}", null);
        }

        public IActionResult DoEmprunt(long id, string titre, string version, long idLoueur)
        {
            IndexViewModel model = new IndexViewModel();
            brApiRepository.PostEmprunt(brApiRepository.GetLoueur(idLoueur).BaseUrl, id);
            BluRay empruntedBluRay = new BluRay();
            empruntedBluRay.Titre = titre;
            empruntedBluRay.Version = version;
            empruntedBluRay.Emprunt = true;
            empruntedBluRay.Proprietaire = idLoueur;
            empruntedBluRay.Disponible = true;
            bluRayBusiness.AddBluRay(empruntedBluRay);
            model.BluRays = brRepository.GetListeBluRay();
            return View("~/Views/Home/AllBluRay.cshtml", model);
        }
    }
}
