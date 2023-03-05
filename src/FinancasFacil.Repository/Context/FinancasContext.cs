using FinancasFacil.Domain.Entities;
using FinancasFacil.Repository.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Context;

public class FinancasContext : DbContext
{
    public FinancasContext(DbContextOptions<FinancasContext> options) : base(options) { }

    public DbSet<Movimento> Movimentos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoriaConfig());
        modelBuilder.ApplyConfiguration(new MovimentoConfig());
    }
}