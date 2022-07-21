using System.Linq.Expressions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework.Services;

public class UserDataService : IUserService
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<User> _nonQueryDataService;

    public UserDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();

        IEnumerable<User> entities = await context.Users.Include(x => x.Characters).ToListAsync();

        return entities;
    }

    public async Task<IEnumerable<User>> GetAllWhere(Expression<Func<User, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        IEnumerable<User> entities = await context.Users.Include(x => x.Characters).Where(predicate).ToListAsync();

        return entities;
    }

    public async Task<User> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Users
            .Include(x => x.Characters)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User> Create(User entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<User> Update(int id, User entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public async Task<User> GetByUsername(string username)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Users
            .Include(x => x.Characters)
            .FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User> GetByEmail(string email)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Users
            .Include(x => x.Characters)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}