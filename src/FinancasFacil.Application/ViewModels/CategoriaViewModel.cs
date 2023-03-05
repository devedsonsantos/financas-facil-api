using FinancasFacil.Application.Extensions;
using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Application.ViewModels;

public class CategoriaViewModel : ViewModelBase
{
    public string? Descricao { get; set; }

    public Categoria ToModel()
    {
        var model = new Categoria();

        return ToModel(model);
    }

    public Categoria ToModel(Categoria model)
    {
        model.Descricao = Descricao ?? model.Descricao;
        model.DataCadastro = DataCadastro ?? DateTime.Now.ToBrazilDateTime();
        model.DataModificacao = DataModificacao ?? model.DataModificacao;

        if (model.Id == Guid.Empty && Id.GetValueOrDefault() == Guid.Empty)
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
            DataExclusao = model.DataExclusao
        };
    }

    public static Categoria Merge(CategoriaViewModel viewModel, Categoria model)
    {
        model.Descricao = viewModel.Descricao ?? model.Descricao;
        model.DataModificacao = DateTime.Now.ToBrazilDateTime();
        model.DataExclusao = viewModel.DataExclusao ?? model.DataExclusao;

        return model;
    }
}
