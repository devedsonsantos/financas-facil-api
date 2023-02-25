namespace FinancasFacil.Domain.Entities;

public class Movimento
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public TipoMovimento Tipo { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public bool Quitado { get; set; }

    public DateTime DataCadastro { get; set; }
    public DateTime? DataModificacao { get; set; }
    public DateTime? DataExclusao { get; set; }

    public Guid CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}

public enum TipoMovimento
{
    Receita,
    Despesa
}