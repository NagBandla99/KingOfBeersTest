using System.Linq.Expressions;

namespace NB.KingOfBeers.DataAccess;

/// <summary>
/// Generic repository for reading and writing data to/from DB.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Add entry.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> Add(T entity);

    /// <summary>
    /// Add range of entries.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task AddAll(List<T> entities);
    
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Get all entries.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAll();

    /// <summary>
    /// get entry by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetById(int id);
    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Delete entry.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Remove(T entity);

    /// <summary>
    /// Update entry.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Update(T entity);
}