using FinancasFacil.Application.Interfaces;
using FinancasFacil.Application.Services;
using FinancasFacil.Repository.Context;
using FinancasFacil.Repository.Interfaces;
using FinancasFacil.Repository.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinancasFacil.IoC;

public static class BootStrapper
{
    public static void RegisterIoC(this IServiceCollection services)
    {
        services.AddScoped<DbContext, FinancasContext>();
        services.AddScoped<IMovimentoRepository, MovimentoRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();

        services.AddScoped<IMovimentoService, MovimentoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
    }
}
