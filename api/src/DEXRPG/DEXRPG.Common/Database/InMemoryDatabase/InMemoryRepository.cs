using System.Linq.Expressions;

namespace DEXRPG.Common.Database.InMemoryDatabase;

public class InMemoryRepository<T>(DbDexRpgContext dbContext) : IRepository<T>
    where T : class
{
    public Task<bool> Create(T model)
    {
        dbContext.Set<T>().Add(model);
        return Task.FromResult(dbContext.SaveChanges() > 0);
    }

    public Task<T?> GetById(Guid id)
    {
        return Task.FromResult(dbContext.Set<T>().Find(id));
    }

    public Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> predicate)
    {
        var result = dbContext.Set<T>().Where(predicate);
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<bool> DeleteMany(Expression<Func<T, bool>> predicate)
    {
        dbContext.RemoveRange(dbContext.Set<T>().Where(predicate));
        return Task.FromResult(dbContext.SaveChanges() > 0);
    }
}