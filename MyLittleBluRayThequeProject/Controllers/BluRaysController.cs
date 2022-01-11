using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Business;
using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BluRaysController
    {
        private readonly ILogger<BluRaysController> _logger;

        private readonly BluRayRepository brRepository;
        private readonly BluRayBusiness brBusiness;

        public BluRaysController(ILogger<BluRaysController> logger)
        {
            _logger = logger;
            brRepository = new BluRayRepository();
        }

        [HttpGet()]
        public ObjectResult Get()
        {
            List<BluRay> br = brRepository.GetListeBluRay();
            List<InfoBluRayViewModel> bluRays = br.ConvertAll(InfoBluRayViewModel.ToModel);
            return new OkObjectResult(bluRays);
        }

        [HttpPost("{IdBluray}/Emprunt")]
        public ObjectResult BorrowBluRay([FromRoute] IdBluRayRoute route)
        {
            try
            {
                if (brRepository.GetBluRay(route.IdBluray) != null)
                {
                    if (brRepository.GetBluRay(route.IdBluray).Disponible)
                    {
                        brBusiness.BorrowBluRay(route.IdBluray);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return new CreatedResult($"{route.IdBluray}", null);
        }


        [HttpDelete("{IdBluray}/Emprunt")]
        public ObjectResult ReturnBluRay([FromRoute] IdBluRayRoute route)
        {
            try
            {
                if (brRepository.GetBluRay(route.IdBluray) != null)
                {
                        brBusiness.ReturnBluRay(route.IdBluray);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return new CreatedResult($"{route.IdBluray}", null);
        }
    }
}
