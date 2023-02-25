using FinancasFacil.Domain.Entities;
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

        MovimentoConfig(modelBuilder);

        CategoriaConfig(modelBuilder);
    }

    #region EntityConfig
    private static void CategoriaConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("Id".ToLower());

            entity.Property(x => x.Descricao)
                .HasColumnName("Descricao".ToLower())
                .HasMaxLength(50);

            entity.Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro".ToLower());

            entity.Property(x => x.DataModificacao)
                .HasColumnName("DataModificacao".ToLower());

            entity.Property(x => x.DataExclusao)
                .HasColumnName("DataExclusao".ToLower());

            entity.HasMany(c => c.Movimentos)
            .WithOne(m => m.Categoria)
            .HasForeignKey(m => m.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

            entity.ToTable("categorias");
        });
    }

    private static void MovimentoConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimento>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("Id".ToLower());
        
            entity.Property(x => x.CategoriaId)
                .HasColumnName("CategoriaId".ToLower());

            entity.Property(x => x.Descricao)
                .HasColumnName("Descricao".ToLower())
                .HasMaxLength(50);

            entity.Property(x => x.Tipo)
                .HasColumnName("Tipo".ToLower());

            entity.Property(x => x.DataVencimento)
                .HasColumnName("DataVencimento".ToLower());

            entity.Property(x => x.Valor)
                .HasColumnName("Valor".ToLower())
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.Observacao)
                .HasColumnName("Observacao".ToLower())
                .HasMaxLength(500);

            entity.Property(x => x.Quitado)
                .HasColumnName("Quitado".ToLower())
                .HasDefaultValue(false)
                .IsRequired();

            entity.Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro".ToLower());

            entity.Property(x => x.DataModificacao)
                .HasColumnName("DataModificacao".ToLower());

            entity.Property(x => x.DataExclusao)
                .HasColumnName("DataExclusao".ToLower());

            entity.HasOne(m => m.Categoria)
                .WithMany(c => c.Movimentos)
                .HasForeignKey(m => m.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.ToTable("movimentos");
        });
    }
    #endregion
}
