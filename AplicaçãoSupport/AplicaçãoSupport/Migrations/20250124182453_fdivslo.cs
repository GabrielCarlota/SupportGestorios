using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicaçãoSupport.Migrations
{
    /// <inheritdoc />
    public partial class fdivslo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atendente",
                columns: table => new
                {
                    Atendente_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome_Atendente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendente", x => x.Atendente_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Empresa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome_Empresa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Empresa_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome_Cliente = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Empresa_id = table.Column<int>(type: "int", nullable: true),
                    EmpresaModelEmpresa_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Empresa_EmpresaModelEmpresa_Id",
                        column: x => x.EmpresaModelEmpresa_Id,
                        principalTable: "Empresa",
                        principalColumn: "Empresa_Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Atendimento_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AtendenteId = table.Column<int>(type: "int", nullable: false),
                    Problema = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Data_Atendimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Data_Inclusão = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Atendimento_Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Atendente_AtendenteId",
                        column: x => x.AtendenteId,
                        principalTable: "Atendente",
                        principalColumn: "Atendente_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_AtendenteId",
                table: "Atendimentos",
                column: "AtendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ClienteId",
                table: "Atendimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EmpresaModelEmpresa_Id",
                table: "Cliente",
                column: "EmpresaModelEmpresa_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Atendente");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
