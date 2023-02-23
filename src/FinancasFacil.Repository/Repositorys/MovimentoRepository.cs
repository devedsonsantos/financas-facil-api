using FinancasFacil.Domain.Entities;
using FinancasFacil.Repository.Context;
using FinancasFacil.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Repositorys;

public class MovimentoRepository : IMovimentoRepository
{
    private readonly FinancasContext _context;

    public MovimentoRepository(FinancasContext context)
    {
        _context = context;
    }
    public async Task<Movimento?> ObterPorIdAsync(Guid id)
    {
        return await _context.Movimentos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.DataExclusao == null);
    }

    public async Task<IEnumerable<Movimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await _context.Movimentos
            .AsNoTracking()
            .Where(x => x.DataVencimento >= dataInicio && 
                        x.DataVencimento <= dataFim &&
                        x.DataExclusao == null)
            .ToListAsync();
    }

    public async Task<IEnumerable<Movimento>> ObterTodosAsync()
    {
        return await _context.Movimentos
            .AsNoTracking()
            .Where(x => x.DataExclusao == null)
            .ToListAsync();
    }

    public async Task<Movimento> AtualizarAsync(Movimento movimento)
    {
        var movimentoReturn = _context.Movimentos
            .Update(movimento);

        await SaveChangesAsync();

        return movimentoReturn.Entity;
    }

    public async Task<Movimento> CadastrarAsync(Movimento movimento)
    {
        var movimentoReturn = await _context.Movimentos
            .AddAsync(movimento);

        await SaveChangesAsync();

        return movimentoReturn.Entity;
    }

    public async Task ExcluirAsync(Movimento movimento)
    {
        _context.Movimentos.Remove(movimento);

        await SaveChangesAsync();
    }

    private async Task<int> SaveChangesAsync()
    {
        var boolean = await _context.SaveChangesAsync();
        await _context.DisposeAsync();

        return boolean;
    }
}
