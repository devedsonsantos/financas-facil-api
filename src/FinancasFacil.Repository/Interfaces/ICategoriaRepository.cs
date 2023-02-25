using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Repository.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> ObterTodosAsync();
    Task<Categoria?> ObterPorIdAsync(Guid id);
    Task<Categoria> CadastrarAsync(Categoria movimento);
    Task<Categoria> AtualizarAsync(Categoria movimento);
    Task ExcluirAsync(Categoria movimento);
}
