using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Poisons;

public class PoisonDeliveryMethodDataService : IDataService<PoisonDeliveryMethod>, IDefaultIncludes<PoisonDeliveryMethod>
{
    private readonly ApocryphaDbContextFactory _contextFactory;
    private readonly NonQueryDataService<PoisonDeliveryMethod> _nonQueryDataService;

    public PoisonDeliveryMethodDataService(ApocryphaDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<PoisonDeliveryMethod>(contextFactory);
    }

    public async Task<IEnumerable<PoisonDeliveryMethod>> GetAll()
    {
        return await GetAllWhere(x => true);
    }

    public async Task<IEnumerable<PoisonDeliveryMethod>> GetAllWhere(Expression<Func<PoisonDeliveryMethod, bool>> predicate)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDeliveryMethods = await GetDefaultIncludes(context)
            .Where(predicate)
            .ToListAsync();

        return poisonDeliveryMethods;
    }

    public async Task<PoisonDeliveryMethod> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var poisonDeliveryMethod = await GetDefaultIncludes(context)
            .FirstOrDefaultAsync(x => x.Id == id);

        return poisonDeliveryMethod;
    }

    public async Task<PoisonDeliveryMethod> Create(PoisonDeliveryMethod entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<PoisonDeliveryMethod> Update(int id, PoisonDeliveryMethod entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }

    public IIncludableQueryable<PoisonDeliveryMethod, object> GetDefaultIncludes(ApocryphaDbContext context)
    {
        return context.PoisonDeliveryMethods.AsNoTracking()
            .Include(x => x.PoisonDeliveryMethodTranslations);
    }
}