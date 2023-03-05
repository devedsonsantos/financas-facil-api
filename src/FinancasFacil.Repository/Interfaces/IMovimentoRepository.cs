using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Repository.Interfaces;

public interface IMovimentoRepository : IRepository<Movimento>
{
    Task<IEnumerable<Movimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
}
