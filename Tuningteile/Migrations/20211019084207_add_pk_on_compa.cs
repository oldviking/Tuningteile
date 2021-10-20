using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class add_pk_on_compa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compatibiliy",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    TuningPartId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compatibiliy", x => new { x.ModelId, x.TuningPartId });
                    table.ForeignKey(
                        name: "FK_compatibiliy_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compatibiliy_TuningPart_TuningPartId",
                        column: x => x.TuningPartId,
                        principalTable: "TuningPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compatibiliy_TuningPartId",
                table: "compatibiliy",
                column: "TuningPartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compatibiliy");
        }
    }
}
