using FinancasFacil.Application.Extensions;
using FinancasFacil.Domain.Entities;

namespace FinancasFacil.Application.ViewModels;

public class MovimentoItemViewModel : ViewModelBase
{
    public string? Descricao { get; set; }
    public TipoMovimento? Tipo { get; set; }
    public DateTime? DataVencimento { get; set; }
    public decimal? Valor { get; set; }
    public string? Observacao { get; set; }
    public bool? Quitado { get; set; }

    public Guid? CategoriaId { get; set; }
    public CategoriaViewModel? Categoria { get; set; }

    public Movimento ToModel()
    {
        var model = new Movimento();

        return ToModel(model);
    }

    public Movimento ToModel(Movimento model)
    {
        model.Descricao = Descricao ?? model.Descricao;
        model.Tipo = Tipo ?? model.Tipo;
        model.DataVencimento = DataVencimento ?? model.DataVencimento;
        model.Valor = Valor ?? model.Valor;
        model.Observacao = Observacao ?? model.Observacao;
        model.CategoriaId = CategoriaId ?? model.CategoriaId;
        model.Categoria = Categoria?.ToModel() ?? model.Categoria;
        model.Quitado = Quitado ?? model.Quitado;
        model.DataCadastro = DataCadastro ?? DateTime.Now.ToBrazilDateTime();
        model.DataModificacao = DataModificacao ?? model.DataModificacao;

        if (model.Id == Guid.Empty && Id.GetValueOrDefault() == Guid.Empty) 
            model.Id = Guid.NewGuid();
        else
            model.Id = Id ?? Guid.NewGuid();

        return model;
    }

    public static MovimentoItemViewModel FromModel(Movimento model)
    {
        return new MovimentoItemViewModel
        {
            Id = model.Id,
            Descricao = model.Descricao,    
            Tipo = model.Tipo,
            DataVencimento = model.DataVencimento,
            Valor = model.Valor,
            Observacao = model.Observacao,
            CategoriaId = model.CategoriaId,
            Categoria = model?.Categoria != null ? CategoriaViewModel.FromModel(model.Categoria) : null,
            Quitado = model.Quitado,
            DataCadastro = model.DataCadastro,
            DataModificacao = model.DataModificacao
        };
    }

    public static Movimento Merge(MovimentoItemViewModel viewModel, Movimento model)
    {
        model.Descricao = viewModel.Descricao ?? model.Descricao;
        model.Tipo = viewModel.Tipo ?? model.Tipo;
        model.DataVencimento = viewModel.DataVencimento ?? model.DataVencimento;
        model.Valor = viewModel.Valor ?? model.Valor;
        model.Observacao = viewModel.Observacao ?? model.Observacao;
        model.CategoriaId = viewModel.CategoriaId ?? model.CategoriaId;
        model.Categoria = viewModel.Categoria?.ToModel() ?? model.Categoria;
        model.Quitado = viewModel.Quitado ?? model.Quitado;
        model.DataModificacao = DateTime.Now.ToBrazilDateTime();

        return model;
    }
}
