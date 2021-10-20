using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class jdj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuningPart_Models_ModelId",
                table: "TuningPart");

            migrationBuilder.DropIndex(
                name: "IX_TuningPart_ModelId",
                table: "TuningPart");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "TuningPart");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelTuningPart");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "TuningPart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TuningPart_ModelId",
                table: "TuningPart",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TuningPart_Models_ModelId",
                table: "TuningPart",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
