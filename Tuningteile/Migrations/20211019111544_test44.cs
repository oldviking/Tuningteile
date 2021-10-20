using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class test44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelTuningPart");

            migrationBuilder.CreateTable(
                name: "compatibility",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    TuningPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compatibility", x => new { x.TuningPartId, x.ModelID });
                    table.ForeignKey(
                        name: "FK_compatibility_Models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compatibility_TuningPart_TuningPartId",
                        column: x => x.TuningPartId,
                        principalTable: "TuningPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_ModelID",
                table: "compatibility",
                column: "ModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compatibility");

            migrationBuilder.CreateTable(
                name: "ModelTuningPart",
                columns: table => new
                {
                    ModelsId = table.Column<int>(type: "int", nullable: false),
                    TuningPartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTuningPart", x => new { x.ModelsId, x.TuningPartsId });
                    table.ForeignKey(
                        name: "FK_ModelTuningPart_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelTuningPart_TuningPart_TuningPartsId",
                        column: x => x.TuningPartsId,
                        principalTable: "TuningPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelTuningPart_TuningPartsId",
                table: "ModelTuningPart",
                column: "TuningPartsId");
        }
    }
}
