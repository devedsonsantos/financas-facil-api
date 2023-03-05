using FinancasFacil.Repository.Context;
using FinancasFacil.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Repositorys;

public class RepositoryGeneric<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly FinancasContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public RepositoryGeneric(FinancasContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
    {
        var entityes = await _dbSet.ToListAsync();

        return entityes;
    }

    public virtual async Task<TEntity> AtualizarAsync(TEntity entity)
    {
        var entityPersisty = _dbSet.Update(entity);
        await SaveChangesAsync();

        return entityPersisty.Entity;
    }

    public virtual async Task<TEntity> CadastrarAsync(TEntity entity)
    {
        var entityPersisty = await _dbSet.AddAsync(entity);
        await SaveChangesAsync();

        return entityPersisty.Entity;
    }

    public virtual async Task ExcluirAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public virtual async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
