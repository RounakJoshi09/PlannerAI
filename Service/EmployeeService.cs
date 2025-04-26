using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class EmployeeService : IEmployeeService
{
    IRepositoryManager _repositoryManager;
    ILoggerManager _loggerManager;

    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }
}