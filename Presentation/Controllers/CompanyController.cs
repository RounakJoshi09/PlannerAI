using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;
using Service.Contracts;
namespace PlannerAI.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        CompanyController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _serviceManager.CompanyService.GetAllCompanies();
                return Ok(companies);
            }
            catch (System.Exception)
            {
                return StatusCode(500, Messages.somethingWentWrong);
            }
        }
    }

}