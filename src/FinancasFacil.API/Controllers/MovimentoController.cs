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

    [HttpGet]
    [Route(nameof(ObterPorId))]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var movimento = await _movimentoService.ObterPorIdAsync(id);

        if (movimento == null)
            return NotFound();

        return Ok(movimento);
    }
}
