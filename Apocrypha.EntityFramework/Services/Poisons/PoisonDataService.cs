using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonDataService : IDataService<Poison>, IDefaultIncludes<Poison>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<Poison> _nonQueryDataService;

    public PoisonDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<Poison>(contextFactory);
    }


    public async Task<IEnumerable<Poison>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<Poison>> GetAllWhere(Expression<Func<Poison, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisons = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisons;
    }

    public async Task<Poison> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poison = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poison;
    }

    public async Task<Poison> Create(Poison entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<Poison> Update(int id, Poison entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<Poison, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.Poisons.AsNoTracking()
            .Include(x => x.Phases).ThenInclude(x => x.PoisonPhaseElements).ThenInclude(x => x.Condition)
            .Include(x => x.Phases).ThenInclude(x => x.PoisonPhaseElements).ThenInclude(x => x.PoisonDuration)
            .Include(x => x.Phases).ThenInclude(x => x.PoisonPhaseElements).ThenInclude(x => x.PoisonDamageTarget)
            .Include(x => x.Phases).ThenInclude(x => x.PoisonPhaseElements).ThenInclude(x => x.PoisonSpecialEffect)
            .Include(x => x.PoisonTranslations)
            .Include(x => x.DeliveryMethod).ThenInclude(x => x.PoisonDeliveryMethodTranslations);
    }
}