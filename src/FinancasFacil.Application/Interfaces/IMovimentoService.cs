using FinancasFacil.Application.ViewModels;
using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Application.Interfaces;

public interface IMovimentoService
{
    Task<IEnumerable<MovimentoViewModel>> ObterTodosAsync();
    Task<IEnumerable<MovimentoViewModel>> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<MovimentoViewModel?> ObterPorIdAsync(Guid id);
    Task<MovimentoViewModel> CadastrarAsync(MovimentoViewModel movimento);
    Task<MovimentoViewModel> AtualizarAsync(MovimentoViewModel movimento);
    Task ExcluirAsync(Guid id);
}
