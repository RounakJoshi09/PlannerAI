using PlannerAI.Entities.Models;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        private readonly RepositoryContext _repositoryContext;
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }

}