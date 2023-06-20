using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NB.KingOfBeers.Database.Context;

namespace NB.KingOfBeers.DataAccess;

/// <inheritdoc />6
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Fields

    protected internal KobDataContext dbContext;
    internal DbSet<T> DbSet;

    #endregion

    public GenericRepository(KobDataContext context)
    {
        this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
        this.DbSet = context.Set<T>();
    }

    #region Public Methods

    public Task<T?> GetById(int id)
    {
        return this.dbContext.Set<T>().FindAsync(id).AsTask();
    }

    public Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
        => this.dbContext.Set<T>().FirstOrDefaultAsync(predicate);

    public async Task<T> Add(T entity)
    {
        await this.dbContext.Set<T>().AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task AddAll(List<T> entities)
    {
        foreach (var item in entities)
        {
            await this.dbContext.Set<T>().AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }
    }

    public Task Update(T entity)
    {
        DbSet.Attach(entity);
        this.dbContext.Entry(entity).State = EntityState.Modified;
        return this.dbContext.SaveChangesAsync();
    }

    public Task Remove(T entity)
    {
        this.dbContext.Set<T>().Remove(entity);
        return this.dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await this.dbContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return await this.dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    #endregion

}