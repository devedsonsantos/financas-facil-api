namespace FinancasFacil.Application.ViewModels;

public class ViewModelBase
{
    public Guid? Id { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataModificacao { get; set; }
    public DateTime? DataExclusao { get; set; }
}
