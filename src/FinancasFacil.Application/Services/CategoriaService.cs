using FinancasFacil.Application.Interfaces;
using FinancasFacil.Application.ViewModels;
using FinancasFacil.Repository.Interfaces;

namespace FinancasFacil.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<CategoriaViewModel?> ObterPorIdAsync(Guid id)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(id);

        return categoria != null ? CategoriaViewModel.FromModel(categoria) : null;
    }

    public async Task<IEnumerable<CategoriaViewModel>> ObterTodosAsync()
    {
        var categorias = await _categoriaRepository.ObterTodosAsync();

        var viewModel = new List<CategoriaViewModel>();

        foreach (var categoria in categorias)
            viewModel.Add(CategoriaViewModel.FromModel(categoria));

        return viewModel;
    }

    public async Task<CategoriaViewModel> AtualizarAsync(CategoriaViewModel viewModel)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(viewModel.Id.GetValueOrDefault());

        if (categoria == null)
            return null;

        categoria = CategoriaViewModel.Merge(viewModel, categoria);

        var categoriaAtualizado = await _categoriaRepository.AtualizarAsync(categoria);

        return CategoriaViewModel.FromModel(categoriaAtualizado);
    }

    public async Task<CategoriaViewModel> CadastrarAsync(CategoriaViewModel viewModel)
    {
        var model = viewModel.ToModel();

        var categoria = await _categoriaRepository.CadastrarAsync(model);

        return CategoriaViewModel.FromModel(categoria);
    }

    public async Task<bool> ExcluirAsync(Guid id)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(id);

        if (categoria == null)
            return false;

        await _categoriaRepository.ExcluirAsync(categoria);

        return true;
    }
}
