using System.Linq.Expressions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services;

public class CharacterDataService : IDataService<Character>, IDefaultIncludes<Character>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<Character> _nonQueryDataService;

    public CharacterDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<Character>(contextFactory);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Character>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Character>> GetAllWhere(Expression<Func<Character, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        IEnumerable<Character> entities = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return entities;
    }

    /// <inheritdoc />
    public async Task<Character> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var character = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return character;
    }

    /// <inheritdoc />
    public async Task<Character> Create(Character entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    /// <inheritdoc />
    public async Task<Character> Update(int id, Character entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    /// <inheritdoc />
    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    /// <inheritdoc />
    public IIncludableQueryable<Character, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.Characters.AsNoTracking()
            .Include(x => x.InventoryItems)
            .Include(x => x.TrueAllignment);
    }
}