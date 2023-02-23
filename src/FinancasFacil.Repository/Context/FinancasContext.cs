using FinancasFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancasFacil.Repository.Context;

public class FinancasContext : DbContext
{
    public FinancasContext(DbContextOptions<FinancasContext> options) : base(options) { }

    public DbSet<Movimento> Movimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movimento>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Observacao)
                .HasMaxLength(500);

            entity.Property(x => x.Quitado)
                .HasDefaultValue(false)
                .IsRequired();

            entity.Property(x => x.Categoria)
                .HasMaxLength(50);

            entity.Property(x => x.Descricao)
                .HasMaxLength(50);

            entity.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)");

            entity.ToTable("movimentos");
        });
    }
}
