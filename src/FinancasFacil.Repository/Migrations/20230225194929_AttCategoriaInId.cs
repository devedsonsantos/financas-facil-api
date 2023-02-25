using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasFacil.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AttCategoriaInId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categorias",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "categorias",
                newName: "Id");
        }
    }
}
