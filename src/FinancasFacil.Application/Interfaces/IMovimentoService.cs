using FinancasFacil.Application.ViewModels;

namespace FinancasFacil.Application.Interfaces;

public interface IMovimentoService
{
    Task<decimal> ObterSaldoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<MovimentosViewModel> ObterTodosAsync();
    Task<MovimentosViewModel> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<MovimentoItemViewModel?> ObterPorIdAsync(Guid id);
    Task<MovimentoItemViewModel> CadastrarAsync(MovimentoItemViewModel viewModel);
    Task<MovimentoItemViewModel> AtualizarAsync(MovimentoItemViewModel viewModel);
    Task<bool> ExcluirAsync(Guid id);
}
