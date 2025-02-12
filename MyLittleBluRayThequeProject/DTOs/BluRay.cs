﻿namespace MyLittleBluRayThequeProject.DTOs
{
    /// <summary>
    /// Dto d'un Disque Blu-Ray
    /// </summary>
    public class BluRay
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
        public Personne Scenariste  { get; set; }

        /// <summary>
        /// Le réalisateur du film
        /// </summary>
        public Personne Realisateur { get; set; }

        /// <summary>
        /// Les acteurs du film
        /// </summary>
        public List<Personne> Acteurs { get; set; }

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
        public List<RefLangue> Langues { get; set; }

        /// <summary>
        /// Sous-titres disponible sur le BR
        /// </summary>
        public List<RefLangue> SsTitres { get; set; }

        /// <summary>
        /// Version du film sur le BR
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// BR emprunté ou non
        /// </summary>
        public bool Emprunt { get; set; }

        /// <summary>
        /// Id du propriétaire
        /// </summary>
        public long Proprietaire { get; set; }
        /// <summary>
        /// Disponibilité du BR
        /// </summary>
        public bool Disponible { get; set; }
    }
}
