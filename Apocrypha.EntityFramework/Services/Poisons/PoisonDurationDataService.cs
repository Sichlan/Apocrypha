using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonDurationDataService : IDataService<PoisonDuration>, IDefaultIncludes<PoisonDuration>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<PoisonDuration> _nonQueryDataService;

    public PoisonDurationDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<PoisonDuration>(contextFactory);
    }


    public async Task<IEnumerable<PoisonDuration>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<PoisonDuration>> GetAllWhere(Expression<Func<PoisonDuration, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDurations = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisonDurations;
    }

    public async Task<PoisonDuration> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDuration = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poisonDuration;
    }

    public async Task<PoisonDuration> Create(PoisonDuration entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<PoisonDuration> Update(int id, PoisonDuration entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<PoisonDuration, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.PoisonDurations.AsNoTracking()
            .Include(x => x.MinDurationIndicator)
            .Include(x => x.MaxDurationIndicator);
    }
}