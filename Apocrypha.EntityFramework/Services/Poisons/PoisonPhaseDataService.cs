using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonPhaseDataService : IDataService<PoisonPhase>, IDefaultIncludes<PoisonPhase>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<PoisonPhase> _nonQueryDataService;

    public PoisonPhaseDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<PoisonPhase>(contextFactory);
    }


    public async Task<IEnumerable<PoisonPhase>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<PoisonPhase>> GetAllWhere(Expression<Func<PoisonPhase, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisons = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisons;
    }

    public async Task<PoisonPhase> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poison = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poison;
    }

    public async Task<PoisonPhase> Create(PoisonPhase entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<PoisonPhase> Update(int id, PoisonPhase entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<PoisonPhase, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.PoisonPhases.AsNoTracking()
            .Include(x => x.Poison)
            .Include(x => x.PoisonPhaseDuration)
            .Include(x => x.PoisonPhaseElements);
    }
}