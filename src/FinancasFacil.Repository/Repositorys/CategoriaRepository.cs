using FinancasFacil.Domain.Entities;
using FinancasFacil.Repository.Context;
using FinancasFacil.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Repositorys;

public class CategoriaRepository : RepositoryGeneric<Categoria>, ICategoriaRepository
{
    private readonly FinancasContext _context;

    public CategoriaRepository(FinancasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Categoria?> ObterPorIdAsync(Guid id)
    {
        return await _context.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.DataExclusao == null);
    }

    public override async Task<IEnumerable<Categoria>> ObterTodosAsync()
    {
        return await _context.Categorias
            .AsNoTracking()
            .Where(x => x.DataExclusao == null)
            .ToListAsync();
    }
}
