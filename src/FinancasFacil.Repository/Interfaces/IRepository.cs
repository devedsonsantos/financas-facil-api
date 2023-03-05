namespace FinancasFacil.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity> CadastrarAsync(TEntity entity);
    Task<TEntity> AtualizarAsync(TEntity entity);
    Task ExcluirAsync(TEntity entity);

    Task<bool> SaveChangesAsync();
}
