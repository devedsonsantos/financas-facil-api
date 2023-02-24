using FinancasFacil.Application.ViewModels;
using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Application.Interfaces;

public interface IMovimentoService
{
    Task<decimal> ObterSaldoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<IEnumerable<MovimentoViewModel>> ObterTodosAsync();
    Task<IEnumerable<MovimentoViewModel>> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<MovimentoViewModel?> ObterPorIdAsync(Guid id);
    Task<MovimentoViewModel> CadastrarAsync(MovimentoViewModel viewModel);
    Task<MovimentoViewModel> AtualizarAsync(MovimentoViewModel viewModel);
    Task<bool> ExcluirAsync(Guid id);
}
