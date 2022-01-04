using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class BluRayInsertViewModel
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Titre du film contenu sur le Blu-Ray
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Le scénariste du film
        /// </summary>
        public int IdScenariste { get; set; }

        /// <summary>
        /// Le réalisateur du film
        /// </summary>
        public int IdRealisateur { get; set; }

        /// <summary>
        /// Les acteurs du film
        /// </summary>
        public List<int> IdActeurs { get; set; }

        /// <summary>
        /// Durée du film
        /// </summary>
        public TimeSpan Duree { get; set; }

        /// <summary>
        /// Date de sortie du film
        /// </summary>
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Langues disponibles sur le BR
        /// </summary>
        public List<int> IdLangues { get; set; }

        /// <summary>
        /// Sous-titres disponible sur le BR
        /// </summary>
        public List<int> IdSsTitres { get; set; }

        /// <summary>
        /// Version du film sur le BR
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// BR emprunté ou non
        /// </summary>
        public bool Emprunt { get; set; }

        /// <summary>
        /// Disponibilité du BR
        /// </summary>
        public bool Disponible { get; set; }


        public static BluRay ToDTO(BluRayInsertViewModel bluRayInsertViewModel)
        {
            if(bluRayInsertViewModel == null)
            {
                return null;
            }
            var bluray = new BluRay
            {
                Id = bluRayInsertViewModel.Id,
                Scenariste = new Personne
                {
                    Id = bluRayInsertViewModel.IdScenariste
                },
                Realisateur = new Personne
                {
                    Id = bluRayInsertViewModel.IdRealisateur
                },
                Acteurs = new List<Personne>(),
                DateSortie = bluRayInsertViewModel.DateSortie,
                Disponible = bluRayInsertViewModel.Disponible,
                Duree = bluRayInsertViewModel.Duree,
                Emprunt = bluRayInsertViewModel.Emprunt,
                Langues = new List<RefLangue>(),
                SsTitres = new List<RefLangue>(),
                Titre = bluRayInsertViewModel.Titre,
                Version = bluRayInsertViewModel.Version

            };
            foreach (var idAct in bluRayInsertViewModel.IdActeurs)
            {
                bluray.Acteurs.Add(new Personne { Id = idAct });
            }
            foreach (var idLangue in bluRayInsertViewModel.IdLangues)
            {
                bluray.Langues.Add(new RefLangue { Id = idLangue });
            }
            foreach (var idLangue in bluRayInsertViewModel.IdSsTitres)
            {
                bluray.SsTitres.Add(new RefLangue { Id = idLangue });
            }
            return bluray;
        }
    }


}
