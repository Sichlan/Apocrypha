using System.Linq.Expressions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services;

public class ConditionDataService : IDataService<Condition>, IDefaultIncludes<Condition>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<Condition> _nonQueryDataService;

    public ConditionDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<Condition>(contextFactory);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Condition>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Condition>> GetAllWhere(Expression<Func<Condition, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        IEnumerable<Condition> entities = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return entities;
    }

    /// <inheritdoc />
    public async Task<Condition> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var character = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return character;
    }

    /// <inheritdoc />
    public async Task<Condition> Create(Condition entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    /// <inheritdoc />
    public async Task<Condition> Update(int id, Condition entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    /// <inheritdoc />
    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    /// <inheritdoc />
    public IIncludableQueryable<Condition, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.Conditions.AsNoTracking()
            .Include(x => x.ConditionTranslations);
    }
}