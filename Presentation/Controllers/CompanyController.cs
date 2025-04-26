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

        public CompanyController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _serviceManager.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(companies);
        }


        [Route("{companyId:guid}")]
        [HttpGet]
        public IActionResult GetCompany(Guid companyId)
        {
            var company = _serviceManager.CompanyService.GetCompany(companyId);
            return Ok(company);
        }
    }

}