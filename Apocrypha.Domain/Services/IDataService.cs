using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apocrypha.CommonObject.Services
{
    public interface IDataService
    {
        public interface IDataService<T>
        {
            Task<IEnumerable<T>> GetAll();

            Task<T> GetByID(int id);

            Task<T> Create(T entity);

            Task<T> Update(int id, T entity);

            Task<bool> Delete(int id);
        }
    }
}