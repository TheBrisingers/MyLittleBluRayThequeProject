using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class InfoBluRayViewModel
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
        /// Date de sortie du film
        /// </summary>
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Version du film sur le BR
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Disponibilité du BR
        /// </summary>
        public bool Disponible { get; set; }

        public static InfoBluRayViewModel ToModel(BluRay dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new InfoBluRayViewModel { Id = dto.Id, Titre = dto.Titre, DateSortie = dto.DateSortie, Version = dto.Version, Disponible = dto.Disponible };
        }
    }
}
