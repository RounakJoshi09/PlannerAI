using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using PlannerAI.Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repositoryManager.Company.GetAllCompanies(false).OrderBy(x => x.Name).ToList();
            var companiesDTO = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
            return companiesDTO;
        }
        catch (Exception ex)
        {
            _loggerManager.LogError($"Error while getting Companies ${ex.Message}");
            _loggerManager.LogError(ex);
            throw;
        }
    }

    public CompanyDTO GetCompany(Guid Id)
    {
        try
        {
            var company = _repositoryManager.Company.GetCompany(Id, trackChanges: false);
            if (company == null)
            {
                throw new CompanyNotFound(Id);
            }
            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return companyDTO;
        }
        catch (System.Exception ex)
        {
            _loggerManager.LogError($"Error while getting Companies ${ex.Message}");
            _loggerManager.LogError(ex);
            throw;
        }
    }
}
