using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Repository.Interfaces;

public interface IMovimentoRepository
{
    Task<IEnumerable<Movimento>> ObterTodosAsync();
    Task<IEnumerable<Movimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    Task<Movimento?> ObterPorIdAsync(Guid id);
    Task<Movimento> CadastrarAsync(Movimento movimento);
    Task<Movimento> AtualizarAsync(Movimento movimento);
    Task ExcluirAsync(Movimento movimento);
}
