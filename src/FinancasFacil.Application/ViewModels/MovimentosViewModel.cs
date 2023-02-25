using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Application.ViewModels;

public class MovimentosViewModel
{
    public List<MovimentoViewModel> Itens { get; set; } = new();
    public decimal Saldo
    {
        get
        {
            decimal saldoAtual = 0;

            foreach (var item in Itens)
            {
                if (item.Tipo == TipoMovimento.Receita)
                    saldoAtual += item.Valor.GetValueOrDefault();
                else
                    saldoAtual -= item.Valor.GetValueOrDefault();
            }

            return saldoAtual;
        }
    }

    public static MovimentosViewModel FromModel(IEnumerable<Movimento> models)
    {
        var viewModel = new MovimentosViewModel();

        foreach (var model in models)
            viewModel.Itens.Add(MovimentoViewModel.FromModel(model));

        return viewModel;
    }
}
