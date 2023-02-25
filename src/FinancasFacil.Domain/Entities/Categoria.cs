    namespace FinancasFacil.Domain.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataModificacao { get; set; }
    public DateTime? DataExclusao { get; set; }

    public List<Movimento>? Movimentos { get; set; }
}
