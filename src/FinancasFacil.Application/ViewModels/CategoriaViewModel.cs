using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Application.ViewModels;

public class CategoriaViewModel
{
    public Guid? Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataModificacao { get; set; }
    public DateTime? DataExclusao { get; set; }
    public List<MovimentoViewModel> Movimentos { get; set; }

    public Categoria ToModel()
    {
        var model = new Categoria();

        return ToModel(model);
    }

    public Categoria ToModel (Categoria model)
    {
        model.Descricao = Descricao ?? model.Descricao;
        model.DataCadastro = DataCadastro ?? model.DataCadastro;
        model.DataModificacao = DataModificacao ?? model.DataModificacao;
        model.DataExclusao = DataExclusao ?? model.DataExclusao;
        model.Movimentos = Movimentos.Select(m => m.ToModel()).ToList();

        if (model.Id == Guid.Empty)
            model.Id = Guid.NewGuid();
        else
            model.Id = Id ?? Guid.NewGuid();

        return model;
    }

    public static CategoriaViewModel FromModel(Categoria model)
    {
        return new CategoriaViewModel
        {
            Id = model.Id,
            Descricao = model.Descricao,
            DataCadastro = model.DataCadastro,
            DataModificacao = model.DataModificacao,
            DataExclusao = model.DataExclusao,
            Movimentos = new List<MovimentoViewModel>(model.Movimentos.Select(m => MovimentoViewModel.FromModel(m)))
        };
    }

    public static Categoria Merge(CategoriaViewModel viewModel, Categoria model)
    {
        model.Descricao = viewModel.Descricao ?? model.Descricao;
        model.DataCadastro = viewModel.DataCadastro ?? model.DataCadastro;
        model.DataModificacao = viewModel.DataModificacao ?? model.DataModificacao;
        model.DataExclusao = viewModel.DataExclusao ?? model.DataExclusao;

        return model;
    }
}
