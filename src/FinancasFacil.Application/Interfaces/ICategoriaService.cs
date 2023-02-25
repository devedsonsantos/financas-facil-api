using FinancasFacil.Application.ViewModels;

namespace FinancasFacil.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaViewModel>> ObterTodosAsync();
    Task<CategoriaViewModel?> ObterPorIdAsync(Guid id);
    Task<CategoriaViewModel> CadastrarAsync(CategoriaViewModel movimento);
    Task<CategoriaViewModel> AtualizarAsync(CategoriaViewModel movimento);
    Task<bool> ExcluirAsync(Guid id);
}
