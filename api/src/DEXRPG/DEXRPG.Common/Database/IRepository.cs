using System.Linq.Expressions;

namespace DEXRPG.Common.Database;

public interface IRepository<T> where T : class
{
    Task<bool> Create(T model);
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> predicate);

    Task<bool> DeleteMany(Expression<Func<T, bool>> predicate);
}