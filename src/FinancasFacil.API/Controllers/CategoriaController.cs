using FinancasFacil.Application.Interfaces;
using FinancasFacil.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinancasFacil.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    [Route(nameof(ObterPorId))]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var categoria = await _categoriaService.ObterPorIdAsync(id);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpGet]
    [Route(nameof(ObterTodos))]
    public async Task<IActionResult> ObterTodos()
    {
        var categorias = await _categoriaService.ObterTodosAsync();

        if (categorias.Count() == 0)
            return NoContent();

        return Ok(categorias);
    }

    [HttpPost]
    [Route(nameof(Cadastrar))]
    public async Task<IActionResult> Cadastrar(CategoriaViewModel viewModel)
    {
        if (viewModel == null)
            return BadRequest();

        var categoria = await _categoriaService.CadastrarAsync(viewModel);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPut]
    [Route(nameof(Atualizar))]
    public async Task<IActionResult> Atualizar(CategoriaViewModel viewModel)
    {
        if (viewModel == null)
            return BadRequest();

        var categoria = await _categoriaService.AtualizarAsync(viewModel);

        if(categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpDelete]
    [Route(nameof(Excluir))]
    public async Task<IActionResult> Excluir(Guid id)
    {
        await _categoriaService.ExcluirAsync(id);

        return NoContent();
    }
}
