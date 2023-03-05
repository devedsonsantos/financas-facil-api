using FinancasFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancasFacil.Repository.EntityConfig;

public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id".ToLower());

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao".ToLower())
            .HasMaxLength(50);

        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro".ToLower());

        builder.Property(x => x.DataModificacao)
            .HasColumnName("DataModificacao".ToLower());

        builder.Property(x => x.DataExclusao)
            .HasColumnName("DataExclusao".ToLower());

        builder.HasMany(c => c.Movimentos)
        .WithOne(m => m.Categoria)
        .HasForeignKey(m => m.CategoriaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("categorias");
    }
}
