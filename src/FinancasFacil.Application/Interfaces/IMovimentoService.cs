using FinancasFacil.Application.ViewModels;

namespace FinancasFacil.Application.Interfaces;

public interface IMovimentoService
{
    Task<decimal> ObterSaldoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<MovimentosViewModel> ObterTodosAsync();
    Task<MovimentosViewModel> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim);
    Task<MovimentoViewModel?> ObterPorIdAsync(Guid id);
    Task<MovimentoViewModel> CadastrarAsync(MovimentoViewModel viewModel);
    Task<MovimentoViewModel> AtualizarAsync(MovimentoViewModel viewModel);
    Task<bool> ExcluirAsync(Guid id);
}
