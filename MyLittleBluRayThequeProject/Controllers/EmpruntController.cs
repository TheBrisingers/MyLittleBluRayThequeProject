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
        private readonly BluRayBusiness bluRayBusiness;

        public EmpruntController(ILogger<EmpruntController> logger)
        {
            _logger = logger;
            brApiRepository = new BluRayApiRepository();
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

        public IActionResult DoEmprunt(EmpruntBluRayBodyViewModel empruntBluRayBody)
        {
            IndexViewModel model = new IndexViewModel();
            brApiRepository.PostEmprunt(brApiRepository.GetLoueur(empruntBluRayBody.IdLoueur).BaseUrl, empruntBluRayBody.idBluRay);
            BluRay empruntedBluRay = new BluRay();
            empruntedBluRay.Titre = empruntBluRayBody.titre;
            empruntedBluRay.Version = empruntBluRayBody.version;
            empruntedBluRay.DateSortie = empruntBluRayBody.DateSortie;
            empruntedBluRay.Emprunt = true;
            empruntedBluRay.Proprietaire = empruntBluRayBody.IdLoueur;
            bluRayBusiness.AddBluRay(empruntedBluRay);

            return View("AllBluRay", model);
        }
    }
}
