using Contracts;
using PlannerAI.Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) => FindAll(trackChanges);
    }
}