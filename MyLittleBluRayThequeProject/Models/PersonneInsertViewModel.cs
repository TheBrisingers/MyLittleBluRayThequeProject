using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class PersonneInsertViewModel
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nom de la personne
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de la personne
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Date de naissance de la personne
        /// </summary>
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// Nationalité de la personne
        /// </summary>
        public string Nationalite { get; set; }

        public static Personne ToDTO(PersonneInsertViewModel personneInsertViewModel)
        {
            if(personneInsertViewModel == null)
            {
                return null;
            }
            var personne = new Personne
            {
                Id = personneInsertViewModel.Id,
                Nom = personneInsertViewModel.Nom,
                Prenom = personneInsertViewModel.Prenom,
                DateNaissance = personneInsertViewModel.DateNaissance,
                Nationalite = personneInsertViewModel.Nationalite,
            };

            return personne;
        }
    }
}
