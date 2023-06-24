using System.Linq.Expressions;

namespace Apocrypha.CommonObject.Services;

public interface IDataService<T>
{
    Task<IEnumerable<T>> GetAll();

    Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> predicate);

    Task<T> GetById(int id);

    Task<T> Create(T entity);

    Task<T> Update(int id, T entity);

    Task<bool> Delete(int id);
}