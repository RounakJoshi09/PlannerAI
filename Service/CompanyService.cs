using System.Threading.Tasks;
using Contracts;
using PlannerAI.Entities.Models;
using Service.Contracts;

namespace Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }

    public IEnumerable<Company> GetAllCompanies()
    {
        try
        {
            var companies = _repositoryManager.Company.GetAllCompanies(false).OrderBy(x => x.Name).ToList();
            return companies;
        }
        catch (Exception ex)
        {
            _loggerManager.LogError($"Error while getting Companies ${ex.Message}");
            _loggerManager.LogError(ex);
            throw;
        }
    }
}
