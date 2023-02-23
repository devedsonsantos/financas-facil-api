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

    public Task<Movimento> AtualizarAsync(Movimento movimento)
    {
        throw new NotImplementedException();
    }

    public async Task<Movimento> CadastrarAsync(Movimento movimento)
    {
        var movimentoReturn = await _context.Movimentos
            .AddAsync(movimento);

        await _context.SaveChangesAsync();

        return movimentoReturn.Entity;
    }

    public Task ExcluirAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Movimento?> ObterPorIdAsync(Guid id)
    {
        return await _context.Movimentos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<IEnumerable<Movimento>> ObterPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFim)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Movimento>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }
}
