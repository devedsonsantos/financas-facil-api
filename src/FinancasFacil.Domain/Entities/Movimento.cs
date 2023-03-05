namespace FinancasFacil.Domain.Entities;

public class Movimento : EntidadeBase
{
    public string Descricao { get; set; }
    public TipoMovimento Tipo { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public bool Quitado { get; set; }

    public Guid? CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}

public enum TipoMovimento
{
    Receita,
    Despesa
}