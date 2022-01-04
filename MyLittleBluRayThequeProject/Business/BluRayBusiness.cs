using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Business
{
    public class BluRayBusiness
    {

        private readonly BluRayRepository bluRayRepository;
        private readonly PersonneRepository personneRepository;
        private readonly LangueRepository langueRepository;

        public BluRayBusiness()
        {
            this.bluRayRepository = new BluRayRepository();
            this.personneRepository = new PersonneRepository();
            this.langueRepository = new LangueRepository();
        }

        /*public BluRay GetBluRay(long idBr)
        {
            BluRay bluRay = bluRayRepository.GetBluRay(idBr);

            if (bluRay == null)
            {
                throw new ArgumentException($"Bluray d'id :{idBr} non trouvé");
            }

            bluRay.Realisateur = personneRepository.GetRealisateurBr(idBr);

            bluRay.Acteurs = personneRepository.GetActeursBr(idBr);

            return bluRay;
        }*/

        public void AddBluRay(BluRay bluRay)
        {
            bluRayRepository.AddBluRay(bluRay);
            List<BluRay> bluRays = bluRayRepository.GetListeBluRay();
            bluRays = bluRays.OrderByDescending(b => b.Id).ToList();
            long idBluRay =-1;

            foreach (var aBluRay in bluRays)
            {
                if(string.Equals(aBluRay.Titre, bluRay.Titre))
                {
                    idBluRay = aBluRay.Id;
                    break;
                }
            }
            if(idBluRay < 0)
            {
                throw new Exception();
            }

            personneRepository.LinkRealisateur(bluRay.Realisateur, idBluRay);
            personneRepository.LinkScenariste(bluRay.Scenariste, idBluRay);
            personneRepository.LinkActeur(bluRay.Acteurs, idBluRay);
            langueRepository.LinkLangue(bluRay.Langues, idBluRay);
            langueRepository.LinkSsTitres(bluRay.Langues, idBluRay);

        }
    }
}
