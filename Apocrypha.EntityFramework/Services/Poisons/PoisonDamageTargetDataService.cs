using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonDamageTargetDataService : IDataService<PoisonDamageTarget>, IDefaultIncludes<PoisonDamageTarget>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<PoisonDamageTarget> _nonQueryDataService;

    public PoisonDamageTargetDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<PoisonDamageTarget>(contextFactory);
    }

    public async Task<IEnumerable<PoisonDamageTarget>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<PoisonDamageTarget>> GetAllWhere(Expression<Func<PoisonDamageTarget, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDeliveryMethods = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisonDeliveryMethods;
    }

    public async Task<PoisonDamageTarget> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDeliveryMethod = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poisonDeliveryMethod;
    }

    public async Task<PoisonDamageTarget> Create(PoisonDamageTarget entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<PoisonDamageTarget> Update(int id, PoisonDamageTarget entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<PoisonDamageTarget, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.PoisonDamageTargets.AsNoTracking()
            .Include(x => x.PoisonDamageTargetTranslations);
    }
}