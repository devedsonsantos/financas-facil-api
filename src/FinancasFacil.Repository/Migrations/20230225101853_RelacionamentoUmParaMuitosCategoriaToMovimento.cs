using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasFacil.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUmParaMuitosCategoriaToMovimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    datamodificacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dataexclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movimentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    datavencimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    observacao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    quitado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    datamodificacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    dataexclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    categoriaid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_movimentos_categorias_categoriaid",
                        column: x => x.categoriaid,
                        principalTable: "categorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimentos_categoriaid",
                table: "movimentos",
                column: "categoriaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentos");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
