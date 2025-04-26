using PlannerAI.Entities;

namespace Entities.Exceptions;

public class CompanyNotFound : NotFoundException
{
    public CompanyNotFound(Guid guid) : base($"Company with id :{guid} not found") { }
}