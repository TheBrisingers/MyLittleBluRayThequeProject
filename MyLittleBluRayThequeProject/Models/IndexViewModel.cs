using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class IndexViewModel
    {
        public List<BluRay> BluRays { get; set; }

        public BluRay SelectedBluRay { get; set; }

        public List<Personne> Personnes { get; set; }

        public List<RefLangue> Langues { get; set; }

        public List<BluRayApi> LoueurBluRays { get; set; }
        public BluRayApi SelectedLoueurBluRays { get; set; }
        public List<Loueur> Loueurs { get; set; }
        public Loueur SelectedLoueur { get; set; }

    }
}
