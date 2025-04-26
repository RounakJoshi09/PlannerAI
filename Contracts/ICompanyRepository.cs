using PlannerAI.Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);

        Company? GetCompany(Guid Id, bool trackChanges);
    }
}