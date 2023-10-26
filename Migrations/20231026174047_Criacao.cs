using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCardapio.Migrations
{
    /// <inheritdoc />
    public partial class Criacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    DiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.DiaId);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    PeriodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.PeriodoId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalasNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalasId);
                });

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    PratoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    DiaId = table.Column<int>(type: "int", nullable: false),
                    Diasid = table.Column<int>(type: "int", nullable: false),
                    PratoNome = table.Column<int>(type: "int", nullable: false),
                    LinkImagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratos", x => x.PratoId);
                    table.ForeignKey(
                        name: "FK_Pratos_Dias_Diasid",
                        column: x => x.Diasid,
                        principalTable: "Dias",
                        principalColumn: "DiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pratos_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "PeriodoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presencas",
                columns: table => new
                {
                    PresencaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalasId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeAlunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presencas", x => x.PresencaId);
                    table.ForeignKey(
                        name: "FK_Presencas_Salas_SalasId",
                        column: x => x.SalasId,
                        principalTable: "Salas",
                        principalColumn: "SalasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_Diasid",
                table: "Pratos",
                column: "Diasid");

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_PeriodoId",
                table: "Pratos",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_SalasId",
                table: "Presencas",
                column: "SalasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropTable(
                name: "Presencas");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
