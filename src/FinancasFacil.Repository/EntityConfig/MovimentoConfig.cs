using FinancasFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancasFacil.Repository.EntityConfig;

public class MovimentoConfig : IEntityTypeConfiguration<Movimento>
{
    public void Configure(EntityTypeBuilder<Movimento> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id".ToLower());

        builder.Property(x => x.CategoriaId)
            .HasColumnName("CategoriaId".ToLower());

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao".ToLower())
            .HasMaxLength(50);

        builder.Property(x => x.Tipo)
            .HasColumnName("Tipo".ToLower());

        builder.Property(x => x.DataVencimento)
            .HasColumnName("DataVencimento".ToLower());

        builder.Property(x => x.Valor)
            .HasColumnName("Valor".ToLower())
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Observacao)
            .HasColumnName("Observacao".ToLower())
            .HasMaxLength(500);

        builder.Property(x => x.Quitado)
            .HasColumnName("Quitado".ToLower())
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro".ToLower());

        builder.Property(x => x.DataModificacao)
            .HasColumnName("DataModificacao".ToLower());

        builder.Property(x => x.DataExclusao)
            .HasColumnName("DataExclusao".ToLower());

        builder.HasOne(m => m.Categoria)
            .WithMany(c => c.Movimentos)
            .HasForeignKey(m => m.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("movimentos");
    }
}
