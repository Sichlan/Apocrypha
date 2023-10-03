using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonPhaseElementDataService : IDataService<PoisonPhaseElement>, IDefaultIncludes<PoisonPhaseElement>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<PoisonPhaseElement> _nonQueryDataService;

    public PoisonPhaseElementDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<PoisonPhaseElement>(contextFactory);
    }


    public async Task<IEnumerable<PoisonPhaseElement>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<PoisonPhaseElement>> GetAllWhere(Expression<Func<PoisonPhaseElement, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisons = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisons;
    }

    public async Task<PoisonPhaseElement> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poison = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poison;
    }

    public async Task<PoisonPhaseElement> Create(PoisonPhaseElement entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<PoisonPhaseElement> Update(int id, PoisonPhaseElement entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<PoisonPhaseElement, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.PoisonPhaseElements.AsNoTracking()
            .Include(x => x.PoisonDuration)
            .Include(x => x.PoisonDamageTarget)
            .Include(x => x.PoisonSpecialEffect)
            .Include(x => x.Condition)
            .Include(x => x.PoisonPhase);
    }
}