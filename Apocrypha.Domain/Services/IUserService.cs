using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;

namespace Apocrypha.CommonObject.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
    }
}