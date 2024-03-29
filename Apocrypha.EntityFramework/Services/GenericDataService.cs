﻿using System.Linq.Expressions;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework.Services;

public class GenericDataService<T> : IDataService<T> where T : DatabaseObject
{
    private readonly ApocryphaDbContextFactory _dbContextFactory;
    private readonly NonQueryDataService<T> _nonQueryDataService;

    public GenericDataService(ApocryphaDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        _nonQueryDataService = new NonQueryDataService<T>(_dbContextFactory);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        using var context = _dbContextFactory.CreateDbContext();

        IEnumerable<T> entities = await context.Set<T>().ToListAsync();

        return entities;
    }

    public async Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> predicate)
    {
        using var context = _dbContextFactory.CreateDbContext();

        IEnumerable<T> entities = await context.Set<T>().Where(predicate).ToListAsync();

        return entities;
    }

    public async Task<T> GetById(int id)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public async Task<T> Create(T entity)
    {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<T> Update(int id, T entity)
    {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _nonQueryDataService.Delete(id);
    }
}