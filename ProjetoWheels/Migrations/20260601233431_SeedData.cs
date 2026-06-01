using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoWheels.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bicicletas",
                columns: new[] { "Id", "Marca", "Status", "Tamanho", "Tipo", "ValorDiaria" },
                values: new object[] { 1, "Caloi", 0, "26", "Elite Carbon", 15m });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CPF", "Email", "Nome", "Telefone" },
                values: new object[] { 1, "12345678900", "felipe@gmail.com", "Felipe Lourenço", "21999999999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
