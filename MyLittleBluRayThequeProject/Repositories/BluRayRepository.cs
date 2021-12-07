using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class BluRayRepository
    {
        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BluRayRepository()
        {

        }

        public List<BluRay> GetListeBluRay()
        {
            return new List<BluRay>
            { 
                new BluRay
                {
                    Id = 0,
                    Titre = "My Little film 1",
                    DateSortie = DateTime.Now,
                    Version = "Courte",
                    Acteurs = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 0,
                            Nom = "Per",
                            Prenom = "Sonne",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        }
                    },
                    Genre = new List<string>
                    {
                        "Romantique", "Timotheecestungenredefilm", "etmoi"
                    },
                    Resume = "Ultima Syriarum est Palaestina per intervalla magna protenta, cultis abundans terris et nitidis et civitates habens quasdam egregias, nullam nulli cedentem sed sibi vicissim velut ad perpendiculum aemulas: Caesaream, quam ad honorem Octaviani principis exaedificavit Herodes, et Eleutheropolim et Neapolim itidemque Ascalonem Gazam aevo superiore exstructas.",
                    Note = 4
                },
                new BluRay
                {
                    Id = 1,
                    Titre = "My Little film 2",
                    DateSortie = DateTime.Now,
                    Version = "Longue",
                    Acteurs = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 1,
                            Nom = "Per",
                            Prenom = "Sonne",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        }
                    },
                    Genre = new List<string>
                    {
                        "Romantique", "Manonaussi"
                    },
                    Resume = "Ultima Syriarum est Palaestina per intervalla magna protenta, cultis abundans terris et nitidis et civitates habens quasdam egregias, nullam nulli cedentem sed sibi vicissim velut ad perpendiculum aemulas: Caesaream, quam ad honorem Octaviani principis exaedificavit Herodes, et Eleutheropolim et Neapolim itidemque Ascalonem Gazam aevo superiore exstructas.",
                    Note = 2
                }
            };
        }
    }
}
