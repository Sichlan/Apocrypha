using System.Linq.Expressions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services;

public class RaceTranslationDataService : IDataService<RaceTranslation>, IDefaultIncludes<RaceTranslation>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<RaceTranslation> _nonQueryDataService;

    public RaceTranslationDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<RaceTranslation>(contextFactory);
    }

    public async Task<IEnumerable<RaceTranslation>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<RaceTranslation>> GetAllWhere(Expression<Func<RaceTranslation, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        IEnumerable<RaceTranslation> entities = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return entities;
    }

    public async Task<RaceTranslation> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var race = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return race;
    }

    public async Task<RaceTranslation> Create(RaceTranslation entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<RaceTranslation> Update(int id, RaceTranslation entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<RaceTranslation, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.RaceTranslations.AsNoTracking()
            .Include(x => x.Race);
    }
}