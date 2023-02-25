using FinancasFacil.Domain.Entities;
using FinancasFacil.Repository.Context;
using FinancasFacil.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Repositorys;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly FinancasContext _context;

    public CategoriaRepository(FinancasContext context)
    {
        _context = context;
    }
    public async Task<Categoria?> ObterPorIdAsync(Guid id)
    {
        return await _context.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.DataExclusao == null);
    }

    public async Task<IEnumerable<Categoria>> ObterTodosAsync()
    {
        return await _context.Categorias
            .AsNoTracking()
            .Where(x => x.DataExclusao == null)
            .ToListAsync();
    }

    public async Task<Categoria> AtualizarAsync(Categoria categoria)
    {
        var categoriaReturn = _context.Categorias
            .Update(categoria);

        await SaveChangesAsync();

        return categoriaReturn.Entity;
    }

    public async Task<Categoria> CadastrarAsync(Categoria categoria)
    {
        var categoriaReturn = await _context.Categorias
            .AddAsync(categoria);

        await SaveChangesAsync();

        return categoriaReturn.Entity;
    }

    public async Task ExcluirAsync(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);

        await SaveChangesAsync();
    }

    private async Task<int> SaveChangesAsync()
    {
        var boolean = await _context.SaveChangesAsync();
        await _context.DisposeAsync();

        return boolean;
    }
}
