using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    RepositoryContext repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        this.repositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges) => trackChanges ? repositoryContext.Set<T>() : repositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> func, bool trackChanges) => trackChanges ? repositoryContext.Set<T>().Where(func) : repositoryContext.Set<T>().Where(func).AsNoTracking();

    public void Create(T data) => repositoryContext.Set<T>().Add(data);

    public void Update(T data) => repositoryContext.Set<T>().Update(data);

    public void Delete(T data) => repositoryContext.Set<T>().Remove(data);

}
