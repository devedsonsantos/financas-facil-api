    namespace FinancasFacil.Domain.Entities;

public class Categoria : EntidadeBase
{
    public string Descricao { get; set; }

    public List<Movimento>? Movimentos { get; set; }
}
