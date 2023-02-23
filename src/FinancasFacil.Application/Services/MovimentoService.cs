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

    public Task<IEnumerable<MovimentoViewModel>> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovimentoViewModel>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MovimentoViewModel> AtualizarAsync(MovimentoViewModel movimento)
    {
        throw new NotImplementedException();
    }

    public async Task<MovimentoViewModel> CadastrarAsync(MovimentoViewModel viewModel)
    {
        var model = viewModel.ToModel();

        var movimento = await _movimentoRepository.CadastrarAsync(model);

        return MovimentoViewModel.FromModel(movimento);
    }

    public Task ExcluirAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
