using Apocrypha.CommonObject.Models.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace Apocrypha.EntityFramework.Services.Common
{
    /// <summary>
    /// Provides a method to get all default includes for the entity <typeparamref name="T"/>, to have it centralized in one place.
    /// </summary>
    /// <typeparam name="T">The database entity</typeparam>
    public interface IDefaultIncludes<T> where T : DatabaseObject
    {
        /// <summary>
        /// Returns an <seealso cref="IIncludableQueryable{TEntity,TProperty}"/> with the default needed includes for <typeparamref name="T"/>. 
        /// </summary>
        /// <param name="context">The database context, from which the entities are fetched</param>
        /// <returns></returns>
        IIncludableQueryable<T, object> GetDefaultIncludes(ApocryphaDbContext context);
    }
}