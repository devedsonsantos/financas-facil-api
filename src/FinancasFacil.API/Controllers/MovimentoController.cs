using FinancasFacil.Application.Interfaces;
using FinancasFacil.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinancasFacil.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MovimentoController : ControllerBase
{
    private readonly IMovimentoService _movimentoService;

    public MovimentoController(IMovimentoService movimentoService)
    {
        _movimentoService = movimentoService;
    }

    [HttpGet]
    [Route(nameof(ObterPorId))]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var movimento = await _movimentoService.ObterPorIdAsync(id);

        if (movimento == null)
            return NotFound();

        return Ok(movimento);
    }

    [HttpGet]
    [Route(nameof(ObterPorPeriodo))]
    public async Task<IActionResult> ObterPorPeriodo(DateTime? dataInicio, DateTime? dataFim)
    {
        var movimento = await _movimentoService.ObterPorPeriodoAsync(dataInicio, dataFim);

        if (movimento.Count() == 0)
            return NoContent();

        return Ok(movimento);
    }

    [HttpGet]
    [Route(nameof(ObterTodos))]
    public async Task<IActionResult> ObterTodos()
    {
        var movimento = await _movimentoService.ObterTodosAsync();

        if (movimento.Count() == 0)
            return NoContent();

        return Ok(movimento);
    }

    [HttpGet]
    [Route(nameof(ObterSaldo))]
    public async Task<decimal> ObterSaldo(DateTime? dataInicio, DateTime? dataFim)
    {
        return await _movimentoService.ObterSaldoAsync(dataInicio, dataFim);
    }

    [HttpPost]
    [Route(nameof(Cadastrar))]
    public async Task<IActionResult> Cadastrar(MovimentoViewModel viewModel)
    {
        if (viewModel == null)
            return BadRequest();

        var movimento = await _movimentoService.CadastrarAsync(viewModel);

        if (movimento == null)
            return NotFound();

        return Ok(movimento);
    }

    [HttpPut]
    [Route(nameof(Atualizar))]
    public async Task<IActionResult> Atualizar(MovimentoViewModel viewModel)
    {
        if (viewModel == null)
            return BadRequest();

        var movimento = await _movimentoService.AtualizarAsync(viewModel);

        if(movimento == null)
            return NotFound();

        return Ok(movimento);
    }

    [HttpDelete]
    [Route(nameof(Excluir))]
    public async Task<IActionResult> Excluir(Guid id)
    {
        await _movimentoService.ExcluirAsync(id);

        return NoContent();
    }
}
