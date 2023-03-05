using FinancasFacil.Domain.Entities;
using FinancasFacil.Repository.Context;
using FinancasFacil.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Repositorys;

public class MovimentoRepository : RepositoryGeneric<Movimento>, IMovimentoRepository
{
    private readonly FinancasContext _context;

    public MovimentoRepository(FinancasContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await _context.Movimentos
            .AsNoTracking()
            .Include(x => x.Categoria)
            .Where(x => x.DataVencimento >= dataInicio &&
                        x.DataVencimento <= dataFim &&
                        x.DataExclusao == null)
            .ToListAsync();
    }

    public override async Task<IEnumerable<Movimento>> ObterTodosAsync()
    {
        return await _context.Movimentos
            .AsNoTracking()
            .Include(x => x.Categoria)
            .Where(x => x.DataExclusao == null)
            .ToListAsync();
    }

    public override async Task<Movimento?> ObterPorIdAsync(Guid id)
    {
        return await _context.Movimentos
            .AsNoTracking()
            .Include(x => x.Categoria)
            .FirstOrDefaultAsync(x => x.Id == id && x.DataExclusao == null);
    }
}
