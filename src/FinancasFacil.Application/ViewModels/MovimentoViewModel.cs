using FinancasFacil.Domain.Entities;
using System.Runtime.CompilerServices;

namespace FinancasFacil.Application.ViewModels;

public class MovimentoViewModel
{
    public Guid? Id { get; set; }
    public string? Descricao { get; set; }
    public TipoMovimento? Tipo { get; set; }
    public DateTime? DataVencimento { get; set; }
    public decimal? Valor { get; set; }
    public string? Observacao { get; set; }
    public string? Categoria { get; set; }
    public bool? Quitado { get; set; }

    public DateTime? DataCadastro { get; set; }
    public DateTime? DataModificacao { get; set; }
    public DateTime? DataExclusao { get; set; }

    public Movimento ToModel()
    {
        var model = new Movimento();

        return ToModel(model);
    }

    public Movimento ToModel(Movimento model)
    {
        model.Id = Id ?? model.Id;
        model.Descricao = Descricao ?? model.Descricao;
        model.Tipo = Tipo ?? model.Tipo;
        model.DataVencimento = DataVencimento ?? model.DataVencimento;
        model.Valor = Valor ?? model.Valor;
        model.Observacao = Observacao ?? model.Observacao;
        model.Categoria = Categoria ?? model.Categoria;
        model.Quitado = Quitado ?? model.Quitado;
        model.DataCadastro = DataCadastro ?? model.DataCadastro;
        model.DataModificacao = DataModificacao ?? model.DataModificacao;
        model.DataExclusao = DataExclusao ?? model.DataExclusao;

        return model;
    }

    public static MovimentoViewModel FromModel(Movimento model)
    {
        return new MovimentoViewModel
        {
            Id = model.Id,
            Descricao = model.Descricao,
            Tipo = model.Tipo,
            DataVencimento = model.DataVencimento,
            Valor = model.Valor,
            Observacao = model.Observacao,
            Categoria = model.Categoria,
            Quitado = model.Quitado,
            DataCadastro = model.DataCadastro,
            DataModificacao = model.DataModificacao,
            DataExclusao = model.DataExclusao
        };
    }
}
