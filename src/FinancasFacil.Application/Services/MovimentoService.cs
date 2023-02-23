using FinancasFacil.Application.Interfaces;
using FinancasFacil.Application.ViewModels;
using FinancasFacil.Repository.Interfaces;

namespace FinancasFacil.Application.Services;

public class MovimentoService : IMovimentoService
{
    private readonly IMovimentoRepository _movimentoRepository;

    public MovimentoService(IMovimentoRepository movimentoRepository)
    {
        _movimentoRepository = movimentoRepository;
    }
    public async Task<MovimentoViewModel?> ObterPorIdAsync(Guid id)
    {
        var movimento = await _movimentoRepository.ObterPorIdAsync(id);

        return movimento != null ? MovimentoViewModel.FromModel(movimento) : null;
    }

    public async Task<IEnumerable<MovimentoViewModel>> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim)
    {
        dataInicio ??= DateTime.UtcNow;
        dataFim ??= DateTime.UtcNow;

        var movimentos = await _movimentoRepository.ObterPorPeriodoAsync(dataInicio, dataFim);
        var movimentosViewModel = new List<MovimentoViewModel>();

        foreach (var movimento in movimentos)
            movimentosViewModel.Add(MovimentoViewModel.FromModel(movimento));

        return movimentosViewModel;
    }

    public async Task<IEnumerable<MovimentoViewModel>> ObterTodosAsync()
    {
        var movimentos = await _movimentoRepository.ObterTodosAsync();
        var movimentosViewModel = new List<MovimentoViewModel>();

        foreach (var movimento in movimentos)
            movimentosViewModel.Add(MovimentoViewModel.FromModel(movimento));

        return movimentosViewModel;
    }

    public async Task<MovimentoViewModel> AtualizarAsync(MovimentoViewModel viewModel)
    {
        var movimento = await _movimentoRepository.ObterPorIdAsync(viewModel.Id.GetValueOrDefault());

        if (movimento == null)
            return null;

        movimento = MovimentoViewModel.Merge(viewModel, movimento);

        var movimentoAtualizado = await _movimentoRepository.AtualizarAsync(movimento);

        return MovimentoViewModel.FromModel(movimentoAtualizado);
    }

    public async Task<MovimentoViewModel> CadastrarAsync(MovimentoViewModel viewModel)
    {
        var model = viewModel.ToModel();

        var movimento = await _movimentoRepository.CadastrarAsync(model);

        return MovimentoViewModel.FromModel(movimento);
    }

    public async Task<bool> ExcluirAsync(Guid id)
    {
        var movimento = await _movimentoRepository.ObterPorIdAsync(id);

        if (movimento == null) 
            return false;

        await _movimentoRepository.ExcluirAsync(movimento);

        return true;
    }
}
