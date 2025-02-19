using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMedii.Migrations
{
    /// <inheritdoc />
    public partial class AddAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agent",
                table: "Clasa_model");

            migrationBuilder.AddColumn<int>(
                name: "AgentID",
                table: "Clasa_model",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasa_model_AgentID",
                table: "Clasa_model",
                column: "AgentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasa_model_Agent_AgentID",
                table: "Clasa_model",
                column: "AgentID",
                principalTable: "Agent",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasa_model_Agent_AgentID",
                table: "Clasa_model");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropIndex(
                name: "IX_Clasa_model_AgentID",
                table: "Clasa_model");

            migrationBuilder.DropColumn(
                name: "AgentID",
                table: "Clasa_model");

            migrationBuilder.AddColumn<string>(
                name: "Agent",
                table: "Clasa_model",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
