using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMedii.Migrations
{
    /// <inheritdoc />
    public partial class Brand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Clasa_model",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Clasa_model",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeBrand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasa_model_BrandID",
                table: "Clasa_model",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasa_model_Brand_BrandID",
                table: "Clasa_model",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasa_model_Brand_BrandID",
                table: "Clasa_model");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Clasa_model_BrandID",
                table: "Clasa_model");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Clasa_model");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Clasa_model",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
