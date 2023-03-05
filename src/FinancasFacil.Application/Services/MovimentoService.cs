using FinancasFacil.Application.Extensions;
using FinancasFacil.Application.Interfaces;
using FinancasFacil.Application.ViewModels;
using FinancasFacil.Repository.Interfaces;

namespace FinancasFacil.Application.Services;

public class MovimentoService : IMovimentoService
{
    private readonly IMovimentoRepository _movimentoRepository;
    private readonly ICategoriaService _categoriaService;

    public MovimentoService(IMovimentoRepository movimentoRepository, ICategoriaService categoriaService)
    {
        _movimentoRepository = movimentoRepository;
        _categoriaService = categoriaService;
    }

    public async Task<MovimentoItemViewModel?> ObterPorIdAsync(Guid id)
    {
        var movimento = await _movimentoRepository.ObterPorIdAsync(id);

        return movimento != null ? MovimentoItemViewModel.FromModel(movimento) : null;
    }

    public async Task<decimal> ObterSaldoAsync(DateTime? dataInicio, DateTime? dataFim)
    {
        MovimentosViewModel movimentos;

        if (dataInicio == null && dataFim == null)
        {
            movimentos = MovimentosViewModel.FromModel(await _movimentoRepository.ObterTodosAsync());
        }
        else
        {
            dataInicio ??= DateTime.Today.ToBrazilDateTime();
            dataFim ??= DateTime.Now.ToBrazilDateTime();

            movimentos = MovimentosViewModel.FromModel(await _movimentoRepository
                .ObterPorPeriodoAsync(dataInicio.GetValueOrDefault(), dataFim.GetValueOrDefault()));
        }

        return movimentos.Saldo;
    }

    public async Task<MovimentosViewModel> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim)
    {
        dataInicio ??= DateTime.Today.ToBrazilDateTime();
        dataFim ??= DateTime.Now.ToBrazilDateTime();

        var movimentosViewModel = MovimentosViewModel.FromModel(await _movimentoRepository
            .ObterPorPeriodoAsync(dataInicio.GetValueOrDefault(), dataFim.GetValueOrDefault()));

        return movimentosViewModel;
    }

    public async Task<MovimentosViewModel> ObterTodosAsync()
    {
        var movimentosViewModel = MovimentosViewModel.FromModel(await _movimentoRepository.ObterTodosAsync());

        return movimentosViewModel;
    }

    public async Task<MovimentoItemViewModel> AtualizarAsync(MovimentoItemViewModel viewModel)
    {
        var movimento = await _movimentoRepository.ObterPorIdAsync(viewModel.Id.GetValueOrDefault());

        if (movimento == null)
            return null;

        var categoria = await _categoriaService.ObterPorIdAsync(viewModel.CategoriaId.GetValueOrDefault());

        if (categoria == null)
            return null;

        movimento.Categoria = categoria.ToModel();

        movimento = MovimentoItemViewModel.Merge(viewModel, movimento);

        var movimentoAtualizado = await _movimentoRepository.AtualizarAsync(movimento);

        return MovimentoItemViewModel.FromModel(movimentoAtualizado);
    }

    public async Task<MovimentoItemViewModel> CadastrarAsync(MovimentoItemViewModel viewModel)
    {
        var model = viewModel.ToModel();

        var movimento = await _movimentoRepository.CadastrarAsync(model);

        return MovimentoItemViewModel.FromModel(movimento);
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
