using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonSpecialEffectDataService : IDataService<PoisonSpecialEffect>, IDefaultIncludes<PoisonSpecialEffect>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<PoisonSpecialEffect> _nonQueryDataService;

    public PoisonSpecialEffectDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<PoisonSpecialEffect>(contextFactory);
    }

    public async Task<IEnumerable<PoisonSpecialEffect>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<PoisonSpecialEffect>> GetAllWhere(Expression<Func<PoisonSpecialEffect, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDeliveryMethods = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisonDeliveryMethods;
    }

    public async Task<PoisonSpecialEffect> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDeliveryMethod = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poisonDeliveryMethod;
    }

    public async Task<PoisonSpecialEffect> Create(PoisonSpecialEffect entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<PoisonSpecialEffect> Update(int id, PoisonSpecialEffect entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<PoisonSpecialEffect, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.PoisonSpecialEffects.AsNoTracking()
            .Include(x => x.PoisonSpecialEffectTranslations);
    }
}