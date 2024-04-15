using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Tabbles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliments",
                columns: table => new
                {
                    AlimentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scientificName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliments", x => x.AlimentId);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlimentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentsId);
                });

            migrationBuilder.CreateTable(
                name: "SingleComponent",
                columns: table => new
                {
                    SingleComponentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlimentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentsId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Componente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unidades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorPor100g = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesvioPadrão = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorMínimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorMáximo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NúmeroDeDadosUtilizado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referências = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeDados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IComponentsComponentsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleComponent", x => x.SingleComponentId);
                    table.ForeignKey(
                        name: "FK_SingleComponent_Components_IComponentsComponentsId",
                        column: x => x.IComponentsComponentsId,
                        principalTable: "Components",
                        principalColumn: "ComponentsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleComponent_IComponentsComponentsId",
                table: "SingleComponent",
                column: "IComponentsComponentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliments");

            migrationBuilder.DropTable(
                name: "SingleComponent");

            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
